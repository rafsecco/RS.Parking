using AutoMapper;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Application.Services;

public class VehicleTypeService : IVehicleTypeService
{
	private readonly IVehicleTypeRepository _vehicleTypeRepo;
	private readonly IMapper _mapper;

	public VehicleTypeService(IVehicleTypeRepository vehicleTypeContracts, IMapper mapper)
	{
		_vehicleTypeRepo = vehicleTypeContracts;
		_mapper = mapper;
	}

	public async Task<List<VehicleTypeDTO>> GetAll()
	{
		try
		{
			var vehicleTypes = await _vehicleTypeRepo.GetAll();
			if (vehicleTypes == null) return null;

			var objReturn = _mapper.Map<List<VehicleTypeDTO>>(vehicleTypes);
			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleTypeDTO> GetById(ushort id)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepo.GetById(id);
			if (vehicleType == null) return null;

			var objReturn = _mapper.Map<VehicleTypeDTO>(vehicleType);
			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleTypeDTO> Add(VehicleTypeDTO model)
	{
		try
		{
			var vehicleType = _mapper.Map<VehicleType>(model);
			var objResult = await _vehicleTypeRepo.Add(vehicleType);

			if (objResult > 0)
			{
				var objReturn = await _vehicleTypeRepo.GetById(vehicleType.Id);
				return _mapper.Map<VehicleTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<VehicleTypeDTO> Update(ushort id, VehicleTypeDTO model)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepo.GetById(id);
			if (vehicleType == null) return null;

			model.Id = vehicleType.Id;
			_mapper.Map(model, vehicleType);
			var objResult = await _vehicleTypeRepo.Update(vehicleType);

			if (objResult > 0)
			{
				var objReturn = await _vehicleTypeRepo.GetById(vehicleType.Id);
				return _mapper.Map<VehicleTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<bool> Delete(ushort vehicleTypeId)
	{
		try
		{
			var vehicleType = await _vehicleTypeRepo.GetById(vehicleTypeId);
			if (vehicleType == null) throw new Exception("VehicleType was not found!");

			var objResult = await _vehicleTypeRepo.Remove(vehicleType);
			return objResult> 0;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
