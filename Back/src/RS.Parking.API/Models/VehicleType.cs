namespace RS.Parking.API.Models;
public class VehicleType
{
	#region Properties
	public ulong Id { get; set; }
	public bool Active { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;
	public decimal Cost { get; set; }    //decimal myMoney = 300.5m;
	public string? Description { get; set; }
	#endregion
}
