using RS.Parking.Domain.Models;

namespace RS.Parking.Domain.Contracts;

public interface IControlInOutRepository
{
	Task<ControlInOut[]> GetControlInOutActiveAsync();
	
	Task<ControlInOut> GetControlInOutByIdAsync(ulong id);

}
