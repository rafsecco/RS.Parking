using Microsoft.AspNetCore.Mvc;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using System.Reflection;
using System.Text;

namespace RS.Parking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ControlInOutController : Controller
{
	//private readonly ILogger<ControlInOutController> _logger;

	//public ControlInOutController(ILogger<ControlInOutController> logger)
	//{
	//	_logger = logger;
	//}

	private readonly IControlInOutService _controlInOutService;

	public ControlInOutController(IControlInOutService controlInOutervice)
	{
		_controlInOutService = controlInOutervice;
	}

	#region Get
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
			var ControlInOut = await _controlInOutService.GetAll();
			if (ControlInOut == null) return NoContent();

			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(ulong id)
	{
		try
		{
			var ControlInOut = await _controlInOutService.GetById(id);
			if (ControlInOut == null) return NoContent();
			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	//[HttpGet("{dateStart:datetime}/{dateEnd:datetime}")]
	[HttpGet("{dateStart:datetime}")]
	public async Task<IActionResult> GetByRange(DateTime dateStart)
	{
		try
		{
			var ControlInOut = await _controlInOutService.GetByRange(dateStart);
			if (ControlInOut == null) return NoContent();
			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpGet("DownloadCSV/{dateStart:datetime}")]
	public async Task<IActionResult> DownloadCSV(DateTime dateStart)
	{
		try
		{
			List<ControlInOutDTO>? ControlInOut = await _controlInOutService.GetByRange(dateStart);
			if (ControlInOut == null) return NoContent();

			var fileName = $"Report_{dateStart.ToString("yyyy_MM_dd")}-{DateTime.Now.ToString("HH:mm:ss")}.csv";
			var textCsv = ConvertToCsv(ControlInOut);
			byte[] bytes = Encoding.UTF8.GetBytes(textCsv);
			var file = File(bytes, "text/csv", fileName);
			return file;
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	// OK
	//[HttpGet("downloadPngFile")]
	//public IActionResult Download()
	//{
	//	var filepath = Path.Combine(@"path", "filename.png");
	//	return File(System.IO.File.ReadAllBytes(filepath), "image/png", System.IO.Path.GetFileName(filepath));
	//}
	#endregion

	[HttpPost]
	public async Task<IActionResult> Post(ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = await _controlInOutService.Add(model);
			if (ControlInOut == null) return BadRequest("Error to add ControlInOut!");
			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(ulong id, ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = await _controlInOutService.Update(id, model);
			if (ControlInOut == null) return BadRequest("Error to update ControlInOut!");
			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	#region Private Methods
	private static string ConvertToCsv<T>(List<T> list, char separatorChar = ';', bool withHeader = true)
	{
		StringBuilder csvBuilder = new StringBuilder();

		// Obtém as propriedades da classe T
		PropertyInfo[] propriedades = typeof(T).GetProperties();

		if (withHeader)
		{
			// Cria o cabeçalho dinamicamente com base nas propriedades
			foreach (var propriedade in propriedades)
			{
				csvBuilder.Append(propriedade.Name);
				csvBuilder.Append(separatorChar);
			}

			// Remove a vírgula extra no final do cabeçalho
			csvBuilder.Length--;

			// Pula para a próxima linha após o cabeçalho
			csvBuilder.AppendLine();
		}

		// Adiciona os dados de cada objeto na lista
		foreach (var item in list)
		{
			foreach (var propriedade in propriedades)
			{
				csvBuilder.Append(propriedade.GetValue(item));
				csvBuilder.Append(separatorChar);
			}
			// Remove a vírgula extra no final da linha
			csvBuilder.Length--;

			csvBuilder.AppendLine(); // Pula para a próxima linha após os dados de cada objeto
		}

		return csvBuilder.ToString();
	}
	#endregion

}
