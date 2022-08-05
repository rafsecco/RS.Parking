using RS.Parking.Application.DTOs;

namespace RS.Parking.Application.Contracts;

public interface IControlInOutService
{
	Task<ControlInOutDTO> AddControlInOut(ControlInOutDTO model);
	
	Task<ControlInOutDTO> UpdateControlInOut(ulong ControlInOutId, ControlInOutDTO model);

	Task<ControlInOutDTO[]> GetControlInOutActiveAsync();

	Task<ControlInOutDTO> GetControlInOutByIdAsync(ulong id);
}
