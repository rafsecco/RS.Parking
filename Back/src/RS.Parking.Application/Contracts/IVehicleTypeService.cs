using RS.Parking.Application.DTOs;

namespace RS.Parking.Application.Contracts;

public interface IVehicleTypeService
{
	Task<List<VehicleTypeDTO>> GetAll();

	Task<VehicleTypeDTO> GetById(ushort id);

	Task<VehicleTypeDTO> Add(VehicleTypeDTO model);

	Task<VehicleTypeDTO> Update(ushort id, VehicleTypeDTO model);

	Task<bool> Delete(ushort id);
}
