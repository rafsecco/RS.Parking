using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class ControlInOutDTO
{
	public ulong Id { get; set; }

	public ushort VehicleTypeId { get; set; }

	public string VehicleTypeName { get; set; }

	public ulong AccordTypeId { get; set; }

	[Required]
	public string LicensePlate { get; set; }
	
	public DateTime DateTimeIn { get; set; } = DateTime.Now;
	
	public DateTime? DateTimeOut { get; set; }
	
	//public VehicleTypeDTO VehicleType { get; set; }
	
	//public AccordTypeDTO AccordType { get; set; }
}
