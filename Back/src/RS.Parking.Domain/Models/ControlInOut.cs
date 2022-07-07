

namespace RS.Parking.Domain.Models;

public class ControlInOut
{
	#region Properties
	public ulong Id { get; set; }
	public string LicensePlate { get; set; }
	public DateTime DateTimeIn { get; set; } = DateTime.Now;
	public DateTime? DateTimeOut { get; set; }

	public ulong VehicleTypeId { get; set; }
	public VehicleType VehicleType { get; set; }
	public ulong AccordTypeId { get; set; }
	public AccordType AccordType { get; set; }

	#endregion
}
