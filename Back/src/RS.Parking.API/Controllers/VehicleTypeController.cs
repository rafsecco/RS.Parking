using Microsoft.AspNetCore.Mvc;
using RS.Parking.API.Data;
using RS.Parking.API.Models;

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

	private readonly DataContext _context;

	public VehicleTypesController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public IEnumerable<VehicleType> Get()
	{
		return _context.VehicleTypes;
	}

	[HttpGet("{id}")]
	public VehicleType Get(ulong id)
	{
		return _context.VehicleTypes.FirstOrDefault(v => v.Id == id);
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
