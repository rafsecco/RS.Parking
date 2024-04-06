using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS.Parking.Domain.Models;

//[Table("tb_ControlInOut")]
public class ControlInOut
{
	#region Properties
	//[Key]
	//[Required]
	//[Column("id_controleInOut", Order = 1, TypeName = "BIGINT UNSIGNED")]
	public ulong Id { get; set; }

	[ForeignKey("VehicleType")]
	public ushort VehicleTypeId { get; set; } = 1;

	[ForeignKey("AccordType")]
	public ushort AccordTypeId { get; set; } = 1;

	public DateTime DateTimeIn { get; set; } = DateTime.Now;

	public DateTime? DateTimeOut { get; set; }

	[Required]
	[MaxLength(7)]
	public string LicensePlate { get; set; }

	//[NotMapped]
	public VehicleType VehicleType { get; set; }

	//[NotMapped]
	public AccordType AccordType { get; set; }
	#endregion

	public string CalculatePrice()
	{
		if (this.DateTimeOut == null) { return "Sem Data Saída"; }

		//double tolerance = (double)Convert.ToInt32(ConfigurationManager.AppSettings.Get("Tolerance")) / 60;    // 0.0833333333333333;	//5 min default
		decimal tolerance = 5 / 60; // 5 min default

		//var objRegister = new Register();
		//var obj = objRegister.GetRegisterById(pId);

		DateTime dtIn = this.DateTimeIn;
		DateTime dtOut = (DateTime)this.DateTimeOut;

		TimeSpan difference = dtOut.Subtract(dtIn);
		decimal totalHours = (decimal)difference.TotalHours;
		var rest = totalHours - Math.Truncate(totalHours);
		decimal totalHoursRounded = (rest > tolerance) ? Math.Ceiling(totalHours) : Math.Floor(totalHours);

		string returnValue;
		decimal totalCost;

		//switch (pAccordType.Ie_AgreementType)
		switch (AccordType.Id)
		
		{
			#region Enum.IE_AgreementType.Total	(Santander: Cobrado a cada 30 min 1 selo)
			case 1:
				//totalHoursRounded /= ((double)pAccordType.Nr_AgreementType / 100);
				totalHoursRounded /= (AccordType.Percentage / 100);
				returnValue = String.Format("{0} Selos", totalHoursRounded);
				break;
			#endregion

			#region Enum.IE_AgreementType.FirstHour	(Boticário: Paga apenas a 1 hora, o restante é normal)
			//case (int)Enumerators.AgreementType.FirstHour:
			case 2:
				//var firstHour = obj.Vehicle.Vl_cost * (pAgreementTypeDTO.Nr_AgreementType % 100 == 0 ? (double)pAgreementTypeDTO.Nr_AgreementType / 100 : 0);
				//var lastHours = (totalHoursRounded - 1.0) * obj.Vehicle.Vl_cost;

				//var firstHourCost = obj.Vehicle.Vl_cost * ((double)pAccordType.Nr_AgreementType / 100);
				//var totalHoursCost = (totalHoursRounded) * obj.Vehicle.Vl_cost;

				var firstHourCost = VehicleType.Cost * (AccordType.Percentage / 100);
				var totalHoursCost = (totalHoursRounded) * VehicleType.Cost;

				totalCost = totalHoursCost - firstHourCost;
				returnValue = String.Format("R$ {0} ", totalCost);
				break;
			#endregion

			#region default		(Sem convenio)
			default:
				totalCost = totalHoursRounded * VehicleType.Cost;
				returnValue = String.Format("R$ {0} ", totalCost);
				break;
				#endregion
		}

		return returnValue;
	}

}
