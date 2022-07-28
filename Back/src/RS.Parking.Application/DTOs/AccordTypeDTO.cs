using RS.Parking.Domain.Enumerables;
using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class AccordTypeDTO
{
	#region Properties
	public ulong Id { get; set; }

	public bool Active { get; set; }
	public DateTime DateCreated { get; set; } = DateTime.Now;

	[Required]
	public string Description { get; set; }

	public EnumAccordType Accord { get; set; }

	[Required]
	public double Percentage { get; set; }
	#endregion
}
