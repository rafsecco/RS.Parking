using AutoMapper;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Application.Services;

public class ControlInOutService : IControlInOutService
{
	private readonly ICoreRepository _coreRepository;
	private readonly IControlInOutRepository _ControlInOutRepository;
	private readonly IMapper _mapper;

	public ControlInOutService(ICoreRepository coreContracts, IControlInOutRepository ControlInOutContracts, IMapper mapper)
	{
		_coreRepository = coreContracts;
		_ControlInOutRepository = ControlInOutContracts;
		_mapper = mapper;
	}

	public async Task<ControlInOutDTO> AddControlInOut(ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = _mapper.Map<ControlInOut>(model);

			_coreRepository.Add(ControlInOut);

			if (await _coreRepository.SaveChangesAsync())
			{
				var objReturn = await _ControlInOutRepository.GetControlInOutByIdAsync(ControlInOut.Id);
				return _mapper.Map<ControlInOutDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<ControlInOutDTO> UpdateControlInOut(ulong ControlInOutId, ControlInOutDTO model)
	{
		try
		{
			var ControlInOut = await _ControlInOutRepository.GetControlInOutByIdAsync(ControlInOutId);
			if (ControlInOut == null) return null;

			model.Id = ControlInOut.Id;

			_mapper.Map(model, ControlInOut);

			_coreRepository.Update(ControlInOut);

			if (await _coreRepository.SaveChangesAsync())
			{
				var objReturn = await _ControlInOutRepository.GetControlInOutByIdAsync(ControlInOut.Id);
				return _mapper.Map<ControlInOutDTO>(objReturn);
			}

			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<bool> DeleteControlInOut(ulong ControlInOutId)
	{
		try
		{
			var ControlInOut = await _ControlInOutRepository.GetControlInOutByIdAsync(ControlInOutId);
			if (ControlInOut == null) throw new Exception("ControlInOut was not found!");

			_coreRepository.Delete(ControlInOut);

			return await _coreRepository.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<ControlInOutDTO[]> GetControlInOutActiveAsync()
	{
		try
		{
			var ControlInOuts = await _ControlInOutRepository.GetControlInOutActiveAsync();
			if (ControlInOuts == null) return null;

			var objReturn = _mapper.Map<ControlInOutDTO[]>(ControlInOuts);

			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<ControlInOutDTO> GetControlInOutByIdAsync(ulong id)
	{
		try
		{
			var ControlInOut = await _ControlInOutRepository.GetControlInOutByIdAsync(id);
			if (ControlInOut == null) return null;

			var objReturn = _mapper.Map<ControlInOutDTO>(ControlInOut);

			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
