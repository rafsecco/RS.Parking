using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class ControlInOutDTO
{
	public ulong Id { get; set; }

	public ushort VehicleTypeId { get; set; }

	public ushort AccordTypeId { get; set; } = 0;

	[Required]
	public string LicensePlate { get; set; }

	public DateTime DateTimeIn { get; set; } = DateTime.UtcNow;

	public DateTime? DateTimeOut { get; set; }

	public VehicleTypeDTO VehicleType { get; set; }

	public AccordTypeDTO AccordType { get; set; }

	public string Price { get; set; }
}
