using RS.Parking.Domain.Enumerables;
using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class AccordTypeDTO
{
	public ulong Id { get; set; }

	public bool Active { get; set; }

	public DateTime DateCreated { get; set; } = DateTime.Now;

	[Required]
	public string Description { get; set; }

	[Required]
	public EnumAccordType Accord { get; set; } = EnumAccordType.NoDiscount;

	[Required]
	public decimal Percentage { get; set; }
}
