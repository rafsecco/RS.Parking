using Microsoft.EntityFrameworkCore;
using RS.Parking.Infrastructure.Contexts;
using RS.Parking.Infrastructure.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;

public class AccordTypeRepository : IAccordTypeRepository
{
	private readonly RSParkingContext _context;

	public AccordTypeRepository(RSParkingContext context)
	{
		_context = context;
		//_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}

	public async Task<AccordType[]> GetAllAccordTypesAsync()
	{
		return await _context.AccordTypes.OrderBy(x => x.Id).ToArrayAsync();
	}

	public async Task<AccordType> GetAccordTypesByIdAsync(ulong id)
	{
		return await _context.AccordTypes
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}
}
