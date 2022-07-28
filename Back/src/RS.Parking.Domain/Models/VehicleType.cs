using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS.Parking.Domain.Models;

//[Table("tb_VehicleType")]
public class VehicleType
{
	#region Properties
	//[Key]
	public ulong Id { get; set; }
	public bool Active { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public decimal Cost { get; set; }    //decimal myMoney = 300.5m;
	public string Description { get; set; }
	#endregion
}
