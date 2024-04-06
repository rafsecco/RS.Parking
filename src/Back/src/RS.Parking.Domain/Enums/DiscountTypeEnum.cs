using System.ComponentModel;

namespace RS.Parking.Domain.Enums;

public static class Enumerators
{
	#region DiscountType
	public enum DiscountTypeEnum
	{
		[Description("No Discount")]
		NoDiscount = 0,

		[Description("Total")]
		Total = 1,

		[Description("First Hour")]
		FirstHour = 2,
	}
	#endregion
}
