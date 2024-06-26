using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class AccordTypeDTO
{
	public ushort Id { get; set; }

	public bool Active { get; set; }

	public DateTime DateCreated { get; set; } = DateTime.UtcNow;

	[Required]
	public string Description { get; set; }

	[Required]
	public ushort DiscountTypeId { get; set; } = 0;

	public decimal Percentage { get; set; }

}
