using RS.Parking.Application.DTOs;

namespace RS.Parking.Application.Contracts;

public interface IControlInOutService
{
	Task<List<ControlInOutDTO>> GetAll();

	Task<ControlInOutDTO> GetById(ulong id);

	Task<ControlInOutDTO> Add(ControlInOutDTO model);

	Task<ControlInOutDTO> Update(ulong id, ControlInOutDTO model);
}
