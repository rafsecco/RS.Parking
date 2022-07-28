using RS.Parking.Application.DTOs;

namespace RS.Parking.Application.Contracts;

public interface IVehicleTypeService
{
	Task<VehicleTypeDTO> AddVehicleType(VehicleTypeDTO model);
	Task<VehicleTypeDTO> UpdateVehicleType(ulong VehicleTypeId, VehicleTypeDTO model);
	Task<bool> DeleteVehicleType(ulong VehicleTypeId);

	Task<VehicleTypeDTO[]> GetAllVehicleTypesAsync();
	Task<VehicleTypeDTO> GetVehicleTypeByIdAsync(ulong id);
}
