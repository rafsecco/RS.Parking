using RS.Parking.Domain.Models;

namespace RS.Parking.Domain.Contracts;

public interface IControlInOutRepository : IDisposable
{
	Task<List<ControlInOut>> GetAll();

	Task<ControlInOut> GetById(ulong id);

	Task<int> Add(ControlInOut entity);

	Task<int> Update(ControlInOut entity);
}
