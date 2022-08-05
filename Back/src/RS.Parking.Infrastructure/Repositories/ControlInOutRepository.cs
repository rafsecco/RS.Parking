using Microsoft.EntityFrameworkCore;
using RS.Parking.Infrastructure.Contexts;
using RS.Parking.Domain.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;

public class ControlInOutRepository : IControlInOutRepository
{
	private readonly RSParkingContext _context;

	public ControlInOutRepository(RSParkingContext context)
	{
		_context = context;
		//_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}

	public async Task<ControlInOut[]> GetControlInOutActiveAsync()
	{
		return await _context.ControlInOut
			.Where(x => x.DateTimeOut == null)
			//.Where(x => DateOnly.FromDateTime(x.DateTimeIn) == date)
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
