using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class ControlInOutDTO
{
	#region Properties
	public ulong Id { get; set; }
	
	[Required]
	public string LicensePlate { get; set; }
	
	public DateTime DateTimeIn { get; set; } = DateTime.Now;
	
	public DateTime? DateTimeOut { get; set; }
	
	public VehicleTypeDTO VehicleType { get; set; }
	
	public AccordTypeDTO AccordType { get; set; }
	#endregion
}
