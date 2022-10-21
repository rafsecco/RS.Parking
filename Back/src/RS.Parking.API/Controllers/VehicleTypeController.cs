using Microsoft.AspNetCore.Mvc;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;

namespace RS.Parking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleTypeController : ControllerBase
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

	public VehicleTypeController(IVehicleTypeService vehicleTypeService)
	{
		_vehicleTypeService = vehicleTypeService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		try
		{
			var vehicleTypes = await _vehicleTypeService.GetAll();
			if (vehicleTypes == null) return NoContent();

			return Ok(vehicleTypes);
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
			var vehicleType = await _vehicleTypeService.GetById(id);
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
			var vehicleType = await _vehicleTypeService.Add(model);
			if (vehicleType == null) return BadRequest("Error to add vehicleType!");
			return Ok(vehicleType);
		}
		catch (Exception ex)
		{
			return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		}
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Put(ushort id, VehicleTypeDTO model)
	{
		try
		{
			var vehicleType = await _vehicleTypeService.Update(id, model);
			if (vehicleType == null) return BadRequest("Error to update vehicleType!");
			return Ok(vehicleType);
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
			var vehicleType = await _vehicleTypeService.GetById(id);
			if (vehicleType == null) return NoContent();

			return await _vehicleTypeService.Delete(id)
				// ? Ok("Deleted")
				? Ok( new { message = "Deleted" } )
				: throw new Exception("A non-specific problem occurred while trying to delete the vehicle type!");
		}
		catch (Exception ex)
		{
			return this.StatusCode(
				StatusCodes.Status500InternalServerError, 
				$"Error trying to delete VehicleType. Error: {ex.Message}"
			);
		}
	}

}
