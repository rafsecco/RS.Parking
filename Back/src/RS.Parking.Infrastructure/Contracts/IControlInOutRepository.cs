using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Contracts;

public interface IControlInOutRepository
{
	Task<ControlInOut[]> GetControlInOutByDateAsync(DateOnly date);
	Task<ControlInOut> GetControlInOutByIdAsync(ulong id);

}
