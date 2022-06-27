using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Contracts;

public interface IAccordTypeRepository
{
	Task<AccordType[]> GetAllAccordTypesAsync();
	Task<AccordType> GetAccordTypesByIdAsync(ulong id);
}
