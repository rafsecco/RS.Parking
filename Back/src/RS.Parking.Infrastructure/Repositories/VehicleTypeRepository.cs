using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;

public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
{
	public VehicleTypeRepository(RSParkingContext context) : base(context) { }
}
