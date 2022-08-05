using AutoMapper;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Application.Services;

public class VehicleTypeService : IVehicleTypeService
{
	private readonly ICoreRepository _coreRepository;
	private readonly IVehicleTypeRepository _vehicleTypeRepository;
	private readonly IMapper _mapper;

	public VehicleTypeService(ICoreRepository coreContracts, IVehicleTypeRepository vehicleTypeContracts, IMapper mapper)
	{
		_coreRepository = coreContracts;
		_vehicleTypeRepository = vehicleTypeContracts;
		_mapper = mapper;
	}

	public async Task<VehicleTypeDTO> AddVehicleType(VehicleTypeDTO model)
	{
		try
		{
			var vehicleType = _mapper.Map<VehicleType>(model);

			_coreRepository.Add(vehicleType);

			if (await _coreRepository.SaveChangesAsync())
			{
				var objReturn = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicleType.Id);
				return _mapper.Map<VehicleTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleTypeDTO> UpdateVehicleType(ulong vehicleTypeId, VehicleTypeDTO model)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicleTypeId);
			if (vehicleType == null) return null;

			model.Id = vehicleType.Id;

			_mapper.Map(model, vehicleType);

			_coreRepository.Update(vehicleType);

			if (await _coreRepository.SaveChangesAsync())
			{
				var objReturn = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicleType.Id);
				return _mapper.Map<VehicleTypeDTO>(objReturn);
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
			var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicleTypeId);
			if (vehicleType == null) throw new Exception("VehicleType was not found!");

			_coreRepository.Delete(vehicleType);

			return await _coreRepository.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleTypeDTO[]> GetAllVehicleTypesAsync()
	{
		try
		{
			var vehicleTypes = await _vehicleTypeRepository.GetAllVehicleTypesAsync();
			if (vehicleTypes == null) return null;

			var objReturn = _mapper.Map<VehicleTypeDTO[]>(vehicleTypes);

			return objReturn;

		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleTypeDTO> GetVehicleTypeByIdAsync(ulong id)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(id);
			if (vehicleType == null) return null;

			var objReturn = _mapper.Map<VehicleTypeDTO>(vehicleType);

			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
