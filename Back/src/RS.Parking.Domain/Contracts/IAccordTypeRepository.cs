using RS.Parking.Domain.Models;

namespace RS.Parking.Domain.Contracts;

public interface IAccordTypeRepository
{
	Task<AccordType[]> GetAllAccordTypesAsync();
	Task<AccordType> GetAccordTypeByIdAsync(ulong id);
}
