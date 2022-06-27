using Microsoft.EntityFrameworkCore;
using RS.Parking.Infrastructure.Contexts;
using RS.Parking.Infrastructure.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;

public class VehicleTypeRepository : IVehicleTypeRepository
{
	private readonly RSParkingContext _context;

	public VehicleTypeRepository(RSParkingContext context)
	{
		_context = context;
		//_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}

	public async Task<VehicleType[]> GetAllVehicleTypesAsync()
	{
		return await _context.VehicleTypes.OrderBy(x => x.Description).ToArrayAsync();
	}

	public async Task<VehicleType> GetVehicleTypesByIdAsync(ulong id)
	{
		return await _context.VehicleTypes
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}
}
