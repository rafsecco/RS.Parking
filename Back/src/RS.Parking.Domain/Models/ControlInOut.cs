using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS.Parking.Domain.Models;

//[Table("tb_ControlInOut")]
public class ControlInOut
{
	#region Properties
	//[Key]
	//[Required]
	//[Column("id_controleInOut", Order = 1, TypeName = "BIGINT UNSIGNED")]
	public ulong Id { get; set; }

	//[ForeignKey("VehicleType")]
	public ushort VehicleTypeId { get; set; }

	//[ForeignKey("AccordType")]
	public ushort? AccordTypeId { get; set; }

	public DateTime DateTimeIn { get; set; } = DateTime.Now;

	public DateTime? DateTimeOut { get; set; }

	//[Required]
	//[MaxLength(7)]
	public string LicensePlate { get; set; }

	//[NotMapped]
	public VehicleType VehicleType { get; set; }

	//[NotMapped]
	public AccordType AccordType { get; set; }
	#endregion
}
