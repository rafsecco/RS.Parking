using RS.Parking.Domain.Models;

namespace RS.Parking.Domain.Contracts;

public interface IVehicleTypeRepository
{
	Task<VehicleType[]> GetAllVehicleTypesAsync();
	Task<VehicleType> GetVehicleTypeByIdAsync(ulong id);
}

