using Microsoft.AspNetCore.Mvc;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;

namespace RS.Parking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ControlInOutController : ControllerBase
{
	//private readonly ILogger<ControlInOutController> _logger;

	//public ControlInOutController(ILogger<ControlInOutController> logger)
	//{
	//	_logger = logger;
	//}

	//[HttpGet(Name = "GetVehicle")]
	//public IActionResult GetAll()
	//{
	//	return Ok();
	//}

	private readonly IControlInOutService _ControlInOutService;

	public ControlInOutController(IControlInOutService ControlInOutervice)
	{
		_ControlInOutService = ControlInOutervice;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
			var ControlInOut = await _ControlInOutService.GetControlInOutActiveAsync();
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
			var ControlInOut = await _ControlInOutService.GetControlInOutByIdAsync(id);
			if (ControlInOut == null) return NoContent();
			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Post(ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = await _ControlInOutService.AddControlInOut(model);
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
			var ControlInOut = await _ControlInOutService.UpdateControlInOut(id, model);
			if (ControlInOut == null) return BadRequest("Error to update ControlInOut!");
			return Ok(ControlInOut);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

}
