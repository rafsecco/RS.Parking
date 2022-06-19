using Microsoft.AspNetCore.Mvc;
using RS.Parking.API.Models;

namespace RS.Parking.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleTypeController : ControllerBase
{
	//private readonly ILogger<VehicleTypeController> _logger;

	//public VehicleTypeController(ILogger<VehicleTypeController> logger)
	//{
	//	_logger = logger;
	//}

	//[HttpGet(Name = "GetVehicle")]
	//public IActionResult GetAll()
	//{
	//	return Ok();
	//}
	
	public IEnumerable<VehicleType> _vehicleTypes = new VehicleType[]
	{
		new VehicleType
		{
			Id = 1,
			Active = true,
			DateCreated = DateTime.Now,
			Cost = 300.5m,
			Description = "Exemplo de Get 1"
		},
		new VehicleType
		{
			Id = 2,
			Active = true,
			DateCreated = DateTime.Now,
			Cost = 310.5m,
			Description = "Exemplo de Get 2"
		}
	};

	[HttpGet]
	public IEnumerable<VehicleType> Get()
	{
		return _vehicleTypes;
	}

	[HttpGet("{id}")]
	public IEnumerable<VehicleType> Get(ulong id)
	{
		return _vehicleTypes.Where(v => v.Id == id);
	}

	[HttpPost]
	public string Post()
	{
		return "Exemplo de Post";
	}

	[HttpPut("{id}")]
	public string Put(int id)
	{
		return $"Exemplo de Put com id = {id}";
	}

	[HttpDelete("{id}")]
	public string Delete(int id)
	{
		return $"Exemplo de Delete com id = {id}";
	}

}
