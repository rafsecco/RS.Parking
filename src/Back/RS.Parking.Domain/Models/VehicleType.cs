using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS.Parking.Domain.Models;

public class VehicleType
{
	#region Properties
	public ushort Id { get; set; }

	public bool Active { get; set; }

	public DateTime DateCreated { get; set; } = DateTime.UtcNow;

	public decimal Cost { get; set; }    //decimal myMoney = 300.5m;

	public string Description { get; set; }
	#endregion
}
