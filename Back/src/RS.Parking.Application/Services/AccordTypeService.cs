using AutoMapper;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Application.Services;

public class AccordTypeService : IAccordTypeService
{
	private readonly ICoreRepository _coreRepository;
	private readonly IAccordTypeRepository _AccordTypeRepository;
	private readonly IMapper _mapper;

	public AccordTypeService(ICoreRepository coreContracts, IAccordTypeRepository AccordTypeContracts, IMapper mapper)
	{
		_coreRepository = coreContracts;
		_AccordTypeRepository = AccordTypeContracts;
		_mapper = mapper;
	}

	public async Task<AccordTypeDTO> AddAccordType(AccordTypeDTO model)
	{
		try
		{
			var AccordType = _mapper.Map<AccordType>(model);

			_coreRepository.Add(AccordType);

			if (await _coreRepository.SaveChangesAsync())
			{
				var objReturn = await _AccordTypeRepository.GetAccordTypeByIdAsync(AccordType.Id);
				return _mapper.Map<AccordTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<AccordTypeDTO> UpdateAccordType(ulong AccordTypeId, AccordTypeDTO model)
	{
		try
		{
			var AccordType = await _AccordTypeRepository.GetAccordTypeByIdAsync(AccordTypeId);
			if (AccordType == null) return null;

			model.Id = AccordType.Id;

			_mapper.Map(model, AccordType);

			_coreRepository.Update(AccordType);

			if (await _coreRepository.SaveChangesAsync())
			{
				var objReturn = await _AccordTypeRepository.GetAccordTypeByIdAsync(AccordType.Id);
				return _mapper.Map<AccordTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<bool> DeleteAccordType(ulong AccordTypeId)
	{
		try
		{
			var AccordType = await _AccordTypeRepository.GetAccordTypeByIdAsync(AccordTypeId);
			if (AccordType == null) throw new Exception("AccordType was not found!");

			_coreRepository.Delete(AccordType);

			return await _coreRepository.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<AccordTypeDTO[]> GetAllAccordTypesAsync()
	{
		try
		{
			var AccordTypes = await _AccordTypeRepository.GetAllAccordTypesAsync();
			if (AccordTypes == null) return null;

			var objReturn = _mapper.Map<AccordTypeDTO[]>(AccordTypes);

			return objReturn;

		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<AccordTypeDTO> GetAccordTypeByIdAsync(ulong id)
	{
		try
		{
			var AccordType = await _AccordTypeRepository.GetAccordTypeByIdAsync(id);
			if (AccordType == null) return null;

			var objReturn = _mapper.Map<AccordTypeDTO>(AccordType);

			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
