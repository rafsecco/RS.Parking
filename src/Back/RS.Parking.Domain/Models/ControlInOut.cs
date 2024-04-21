using RS.Parking.Domain.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RS.Parking.Domain.Models;

public class ControlInOut
{
	#region Properties
	public ulong Id { get; set; }

	[Required]
	public ushort VehicleTypeId { get; set; } = 1;

	[Required]
	public ushort AccordTypeId { get; set; } = 1;

	[Required]
	public DateTime DateTimeIn { get; set; } = DateTime.Now;

	public DateTime? DateTimeOut { get; set; }

	[Required]
	[MaxLength(7)]
	public string LicensePlate { get; set; }

	/* EF Relation */
	public VehicleType VehicleType { get; set; }

	/* EF Relation */
	public AccordType AccordType { get; set; }
	#endregion

	public string CalculatePrice()
	{
		if (this.DateTimeOut == null) { return "Sem Data Saída"; }

		// Define a cultura padrão para toda a aplicação
		CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
		// Ou, se desejar definir a cultura para formatação de texto e exibição de recursos:
		// CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");


		//double tolerance = (double)Convert.ToInt32(ConfigurationManager.AppSettings.Get("Tolerance")) / 60;    // 0.0833333333333333;	//5 min default
		double tolerance = 5.0; // 5 min default
		//decimal tolerance = 5 / 60; // 5 min default

		DateTime dtIn = this.DateTimeIn;
		DateTime dtOut = (DateTime)this.DateTimeOut;

		TimeSpan difference = dtOut.Subtract(dtIn);
		double totalHours = (double)difference.TotalHours;
		var rest = totalHours - Math.Truncate(totalHours);
		double totalHoursRounded = (rest > tolerance) ? Math.Ceiling(totalHours) : Math.Floor(totalHours);

		string returnValue;
		decimal totalCost;

		switch (this.AccordType.DiscountTypeId)
		{
			#region Enum.IE_AgreementType.Total	(Santander: Cobrado a cada 30 min 1 selo)
			case (ushort)EnumAccordType.Total:
				totalHoursRounded /= AccordType.Percentage;
				returnValue = String.Format("{0} Selos", totalHoursRounded);
				break;
			#endregion

			#region Enum.IE_AgreementType.FirstHour	(Boticário: Paga apenas a 1 hora, o restante é normal)
			case (ushort)EnumAccordType.FirstHour:
				var firstHourCost = this.VehicleType.Cost * (decimal)this.AccordType.Percentage;
				var totalHoursCost = this.VehicleType.Cost * (decimal)totalHoursRounded;

				totalCost = totalHoursCost - firstHourCost;
				returnValue = String.Format("{0:C} ", totalCost);
				break;
			#endregion

			#region default	(Sem convenio)
			default:
				totalCost = this.VehicleType.Cost * (decimal)totalHoursRounded;
				returnValue = String.Format("{0:C} ", totalCost);
				break;
			#endregion
		}

		return returnValue;
	}

}
