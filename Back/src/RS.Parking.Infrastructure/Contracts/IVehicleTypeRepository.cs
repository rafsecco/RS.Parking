using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Contracts;

public interface IVehicleTypeRepository
{
	Task<VehicleType[]> GetAllVehicleTypesAsync();
	Task<VehicleType> GetVehicleTypeByIdAsync(ulong id);
}

