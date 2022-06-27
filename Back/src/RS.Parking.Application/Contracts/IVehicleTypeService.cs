using RS.Parking.Domain.Models;

namespace RS.Parking.Application.Contracts;

public interface IVehicleTypeService
{
	Task<VehicleType> AddVehicleType(VehicleType model);
	Task<VehicleType> UpdateVehicleType(ulong vehicleTypeId, VehicleType model);
	Task<bool> DeleteVehicleType(ulong vehicleTypeId);

	Task<VehicleType[]> GetAllVehicleTypesAsync();
	Task<VehicleType> GetVehicleTypesByIdAsync(ulong id);
}
