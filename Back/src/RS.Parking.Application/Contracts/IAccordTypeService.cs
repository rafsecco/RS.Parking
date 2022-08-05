using RS.Parking.Application.DTOs;

namespace RS.Parking.Application.Contracts;

public interface IAccordTypeService
{
	Task<AccordTypeDTO> AddAccordType(AccordTypeDTO model);
	
	Task<AccordTypeDTO> UpdateAccordType(ulong AccordTypeId, AccordTypeDTO model);
	
	Task<bool> DeleteAccordType(ulong AccordTypeId);

	Task<AccordTypeDTO[]> GetAllAccordTypesAsync();
	
	Task<AccordTypeDTO> GetAccordTypeByIdAsync(ulong id);
}
