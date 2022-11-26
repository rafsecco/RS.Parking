namespace RS.Parking.Domain.Models;

public class AccordType
{
	#region Properties
	
	public ushort Id { get; set; }

	public bool Active { get; set; }
	
	public DateTime DateCreated { get; set; } = DateTime.Now;

	public ushort Accord { get; set; } = 0;
	
	public decimal Percentage { get; set; }

	public string Description { get; set; }
	#endregion
}
