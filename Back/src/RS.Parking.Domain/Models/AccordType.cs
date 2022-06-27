
using RS.Parking.Domain.Enumerables;

namespace RS.Parking.Domain.Models;

public class AccordType
{
    #region Properties
    public ulong Id { get; set; }
    public bool Active { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public EnumAccordType Accord { get; set; }
    public double Percentage { get; set; }
	#endregion
}
