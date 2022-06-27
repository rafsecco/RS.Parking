using Microsoft.AspNetCore.Mvc;
using RS.Parking.Domain.Models;
using RS.Parking.Application.Contracts;

namespace RS.Parking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleTypesController : ControllerBase
{
	//private readonly ILogger<VehicleTypesController> _logger;

	//public VehicleTypesController(ILogger<VehicleTypesController> logger)
	//{
	//	_logger = logger;
	//}

	//[HttpGet(Name = "GetVehicle")]
	//public IActionResult GetAll()
	//{
	//	return Ok();
	//}

	private readonly IVehicleTypeService _vehicleTypeService;

	public VehicleTypesController(IVehicleTypeService vehicleTypeService)
	{
		_vehicleTypeService = vehicleTypeService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
			var vehicleTypes = await _vehicleTypeService.GetAllVehicleTypesAsync();
			if (vehicleTypes == null) return NotFound("No vehicleType was found!");
			return Ok(vehicleTypes);
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
			var vehicleType = await _vehicleTypeService.GetVehicleTypesByIdAsync(id);
			if (vehicleType == null) return NotFound("No vehicleType was found!");
			return Ok(vehicleType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Post(VehicleType model)
	{
		try
		{
			var vehicleType = await _vehicleTypeService.AddVehicleType(model);
			if (vehicleType == null) return BadRequest("Error to add vehicleType!");
			return Ok(vehicleType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(ulong id, VehicleType model)
	{
		try
		{
			var vehicleType = await _vehicleTypeService.UpdateVehicleType(id, model);
			if (vehicleType == null) return BadRequest("Error to update vehicleType!");
			return Ok(vehicleType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(ulong id)
	{
		try
		{
			return await _vehicleTypeService.DeleteVehicleType(id) 
				? Ok("Deleted") 
				: BadRequest("");
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

}
