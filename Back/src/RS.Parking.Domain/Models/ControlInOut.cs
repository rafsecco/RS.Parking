

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS.Parking.Domain.Models;

//[Table("tb_ControlInOut")]
public class ControlInOut
{
	#region Properties
	//[Key]
	//[Required]
	public ulong Id { get; set; }

	//[Required]
	//[MaxLength(100)]
	public string LicensePlate { get; set; }
	
	public DateTime DateTimeIn { get; set; } = DateTime.Now;
	
	public DateTime? DateTimeOut { get; set; }

	//[ForeignKey("FK_tbVehicleType")]
	public ulong VehicleTypeId { get; set; }

	//[NotMapped]
	public VehicleType VehicleType { get; set; }
	
	//[ForeignKey("FK_tbVehicleType")]
	public ulong AccordTypeId { get; set; }

	//[NotMapped]
	public AccordType AccordType { get; set; }

	#endregion
}
