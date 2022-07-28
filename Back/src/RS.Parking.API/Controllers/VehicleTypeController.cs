using Microsoft.AspNetCore.Mvc;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;

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
			if (vehicleTypes == null) return NoContent();

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
			var vehicleType = await _vehicleTypeService.GetVehicleTypeByIdAsync(id);
			if (vehicleType == null) return NoContent();
			return Ok(vehicleType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Post(VehicleTypeDTO model)
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
	public async Task<IActionResult> Put(ulong id, VehicleTypeDTO model)
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
			var vehicleType = await _vehicleTypeService.GetVehicleTypeByIdAsync(id);
			if (vehicleType == null) return NoContent();

			return await _vehicleTypeService.DeleteVehicleType(id)
				? Ok("Deleted!")
				: throw new Exception("A non-specific problem occurred while trying to delete the vehicle type!");
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, 
				  $"Error trying to delete VehicleType. Error: {ex.Message}");
		}
	}

}
