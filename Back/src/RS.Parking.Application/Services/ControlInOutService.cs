using AutoMapper;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Application.Services;

public class ControlInOutService : IControlInOutService
{
	private readonly IControlInOutRepository _controlInOutRepo;
	private readonly IVehicleTypeService _vehicleTypeService;
	private readonly IMapper _mapper;

	public ControlInOutService(
		IControlInOutRepository controlInOutRepo,
		IVehicleTypeService vehicleTypeService,
		IMapper mapper)
	{
		_controlInOutRepo = controlInOutRepo;
		_vehicleTypeService = vehicleTypeService;
		_mapper = mapper;
	}

	public async Task<List<ControlInOutDTO>> GetAll()
	{
		try
		{
			var ControlInOuts = await _controlInOutRepo.GetAll();
			if (ControlInOuts == null) return null;

			var objReturn = _mapper.Map<List<ControlInOutDTO>>(ControlInOuts);
			objReturn.ForEach(x => x.VehicleTypeName = _vehicleTypeService.GetById(x.VehicleTypeId).Result.Description);
			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<ControlInOutDTO> GetById(ulong id)
	{
		try
		{
			var ControlInOut = await _controlInOutRepo.GetById(id);
			if (ControlInOut == null) return null;

			var objreturn = _mapper.Map<ControlInOutDTO>(ControlInOut);
			objreturn.VehicleTypeName = _vehicleTypeService.GetById(objreturn.VehicleTypeId).Result.Description;
			return objreturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<ControlInOutDTO> Add(ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = _mapper.Map<ControlInOut>(model);

			var objResult = await _controlInOutRepo.Add(ControlInOut);

			if (objResult > 0)
			{
				var objReturn = await _controlInOutRepo.GetById(ControlInOut.Id);
				return _mapper.Map<ControlInOutDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<ControlInOutDTO> Update(ulong id, ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = await _controlInOutRepo.GetById(id);
			if (ControlInOut == null) return null;

			model.Id = ControlInOut.Id;

			_mapper.Map(model, ControlInOut);

			var objResult = await _controlInOutRepo.Update(ControlInOut);

			if (objResult > 0)
			{
				var objReturn = await _controlInOutRepo.GetById(ControlInOut.Id);
				return _mapper.Map<ControlInOutDTO>(objReturn);
			}

			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<List<ControlInOutDTO>> GetByRange(DateTime pDate)
	{
		try
		{
			var ControlInOuts = await _controlInOutRepo.GetByRange(pDate);
			if (ControlInOuts == null) return null;

			var objReturn = _mapper.Map<List<ControlInOutDTO>>(ControlInOuts);
			objReturn.ForEach(x => x.VehicleTypeName = _vehicleTypeService.GetById(x.VehicleTypeId).Result.Description);
			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
