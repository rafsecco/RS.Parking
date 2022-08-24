using AutoMapper;
using RS.Parking.Application.Contracts;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Application.Services;

public class AccordTypeService : IAccordTypeService
{
	private readonly IAccordTypeRepository _accordTypeRepo;
	private readonly IMapper _mapper;

	public AccordTypeService(IAccordTypeRepository accordTypeContracts, IMapper mapper)
	{
		_accordTypeRepo = accordTypeContracts;
		_mapper = mapper;
	}

	public async Task<List<AccordTypeDTO>> GetAll()
	{
		try
		{
			var AccordTypes = await _accordTypeRepo.GetAll();
			if (AccordTypes == null) return null;

			var objReturn = _mapper.Map<List<AccordTypeDTO>>(AccordTypes);
			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<AccordTypeDTO> GetById(ushort id)
	{
		try
		{
			var AccordType = await _accordTypeRepo.GetById(id);
			if (AccordType == null) return null;

			var objReturn = _mapper.Map<AccordTypeDTO>(AccordType);
			return objReturn;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<AccordTypeDTO> Add(AccordTypeDTO model)
	{
		try
		{
			var AccordType = _mapper.Map<AccordType>(model);
			var objResult = await _accordTypeRepo.Add(AccordType);

			if (objResult > 0)
			{
				var objReturn = await _accordTypeRepo.GetById(AccordType.Id);
				return _mapper.Map<AccordTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<AccordTypeDTO> Update(ushort id, AccordTypeDTO model)
	{
		try
		{
			var AccordType = await _accordTypeRepo.GetById(id);
			if (AccordType == null) return null;

			model.Id = AccordType.Id;
			_mapper.Map(model, AccordType);
			var objResult = await _accordTypeRepo.Update(AccordType);

			if (objResult > 0)
			{
				var objReturn = await _accordTypeRepo.GetById(AccordType.Id);
				return _mapper.Map<AccordTypeDTO>(objReturn);
			}
			return null;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public async Task<bool> Delete(ushort id)
	{
		try
		{
			var AccordType = await _accordTypeRepo.GetById(id);
			if (AccordType == null) throw new Exception("AccordType was not found!");

			var objReturn = await _accordTypeRepo.Remove(AccordType);
			return objReturn > 0;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}
