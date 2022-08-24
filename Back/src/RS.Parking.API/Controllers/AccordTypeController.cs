using Microsoft.AspNetCore.Mvc;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;

namespace RS.Parking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccordTypeController : ControllerBase
{
	//private readonly ILogger<AccordTypesController> _logger;

	//public AccordTypesController(ILogger<AccordTypesController> logger)
	//{
	//	_logger = logger;
	//}

	//[HttpGet(Name = "GetVehicle")]
	//public IActionResult GetAll()
	//{
	//	return Ok();
	//}

	private readonly IAccordTypeService _accordTypeService;

	public AccordTypeController(IAccordTypeService AccordTypeService)
	{
		_accordTypeService = AccordTypeService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
			var AccordTypes = await _accordTypeService.GetAll();
			if (AccordTypes == null) return NoContent();

			return Ok(AccordTypes);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(ushort id)
	{
		try
		{
			var AccordType = await _accordTypeService.GetById(id);
			if (AccordType == null) return NoContent();
			return Ok(AccordType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Post(AccordTypeDTO model)
	{
		try
		{
			var AccordType = await _accordTypeService.Add(model);
			if (AccordType == null) return BadRequest("Error to add AccordType!");
			return Ok(AccordType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(ushort id, AccordTypeDTO model)
	{
		try
		{
			var AccordType = await _accordTypeService.Update(id, model);
			if (AccordType == null) return BadRequest("Error to update AccordType!");
			return Ok(AccordType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(ushort id)
	{
		try
		{
			var AccordType = await _accordTypeService.GetById(id);
			if (AccordType == null) return NoContent();

			return await _accordTypeService.Delete(id)
				? Ok("Deleted!")
				: throw new Exception("A non-specific problem occurred while trying to delete the acoord type!");
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError,
				  $"Error trying to delete AccordType. Error: {ex.Message}");
		}
	}

}
