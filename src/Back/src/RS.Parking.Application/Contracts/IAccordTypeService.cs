using RS.Parking.Application.DTOs;

namespace RS.Parking.Application.Contracts;

public interface IAccordTypeService
{
	Task<List<AccordTypeDTO>> GetAll();

	Task<AccordTypeDTO> GetById(ushort id);

	Task<AccordTypeDTO> Add(AccordTypeDTO model);

	Task<AccordTypeDTO> Update(ushort id, AccordTypeDTO model);

	Task<bool> Delete(ushort id);
}
