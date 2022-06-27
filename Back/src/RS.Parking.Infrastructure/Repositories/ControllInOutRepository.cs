using Microsoft.EntityFrameworkCore;
using RS.Parking.Infrastructure.Contexts;
using RS.Parking.Infrastructure.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;

public class ControllInOutRepository : IControlInOutRepository
{
	private readonly RSParkingContext _context;

	public ControllInOutRepository(RSParkingContext context)
	{
		_context = context;
		//_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}

	public async Task<ControlInOut[]> GetControlInOutByDateAsync(DateOnly date)
	{
		return await _context.ControlInOut
			.Where(x => DateOnly.FromDateTime(x.DateTimeIn) == date)
			.OrderBy(x => x.Id)
			.ToArrayAsync();
	}

	public async Task<ControlInOut> GetControlInOutByIdAsync(ulong id)
	{
		return await _context.ControlInOut
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}
}
