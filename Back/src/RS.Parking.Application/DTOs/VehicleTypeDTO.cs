using System.ComponentModel.DataAnnotations;

namespace RS.Parking.Application.DTOs;

public class VehicleTypeDTO
{
	public ulong Id { get; set; }
	
	public bool Active { get; set; }
	
	public DateTime DateCreated { get; set; } = DateTime.Now;
	
	[Required]
	//[RegularExpression(@"^\d+(\.\d{1,2})?$")]
	[Range(0, 9999999999999999.99)]
	public decimal Cost { get; set; }    //decimal myMoney = 300.5m;
	
	[Required]
	[StringLength(100, MinimumLength = 3, ErrorMessage = "Allowed range from 3 to 100 characters")]
	//[MinLength(3, ErrorMessage = "")]
	//[MaxLength(100, ErrorMessage = "")]
	public string Description { get; set; }

}