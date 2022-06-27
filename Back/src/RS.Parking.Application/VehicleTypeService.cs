using RS.Parking.Application.Contracts;
using RS.Parking.Domain.Models;
using RS.Parking.Infrastructure.Contracts;

namespace RS.Parking.Application;

public class VehicleTypeService : IVehicleTypeService
{
	private readonly ICoreRepository _coreRepository;
	private readonly IVehicleTypeRepository _vehicleTypeRepository;

	public VehicleTypeService(ICoreRepository coreContracts, IVehicleTypeRepository vehicleTypeContracts)
	{
		_coreRepository = coreContracts;
		_vehicleTypeRepository = vehicleTypeContracts;
	}

	public async Task<VehicleType> AddVehicleType(VehicleType model)
	{
		try
		{
			_coreRepository.Add<VehicleType>(model);

			if (await _coreRepository.SaveChangesAsync())
			{
				return await _vehicleTypeRepository.GetVehicleTypesByIdAsync(model.Id);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleType> UpdateVehicleType(ulong vehicleTypeId, VehicleType model)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepository.GetVehicleTypesByIdAsync(vehicleTypeId);
			if (vehicleType == null) return null;
			
			model.Id = vehicleTypeId;
			_coreRepository.Update(model);

			if (await _coreRepository.SaveChangesAsync())
			{
				return model;
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<bool> DeleteVehicleType(ulong vehicleTypeId)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepository.GetVehicleTypesByIdAsync(vehicleTypeId);
			if (vehicleType == null) throw new Exception("VehicleType was not found!");

			_coreRepository.Delete(vehicleType);

			return await _coreRepository.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleType[]> GetAllVehicleTypesAsync()
	{
		try
		{
			var vehicleTypes = await _vehicleTypeRepository.GetAllVehicleTypesAsync();
			if (vehicleTypes == null) return null;
			return vehicleTypes;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleType> GetVehicleTypesByIdAsync(ulong id)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepository.GetVehicleTypesByIdAsync(id);
			if (vehicleType == null) return null;
			return vehicleType;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
