using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;

public class ControlInOutRepository : IControlInOutRepository
{
	private readonly RSParkingContext _context;

	public ControlInOutRepository(RSParkingContext context)
	{
		_context = context;
	}

	public async Task<List<ControlInOut>> GetAll()
	{
		var retorno = await _context.ControlInOut
			.Where(x => x.DateTimeOut == null)
			.Include(v => v.VehicleType)
			.Include(a => a.AccordType)
			.OrderBy(x => x.DateTimeIn)
			.ToListAsync();
		return retorno;
	}

	public async Task<ControlInOut> GetById(ulong id)
	{
		return await _context.ControlInOut
			.AsNoTracking()
			.Include(v => v.VehicleType)
			.Include(a => a.AccordType)
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task<int> Add(ControlInOut entity)
	{
		_context.ControlInOut.Add(entity);
		return await _context.SaveChangesAsync();
	}

	public async Task<int> Update(ControlInOut entity)
	{
		_context.ControlInOut.Update(entity);
		return await _context.SaveChangesAsync();
	}

	public async Task<List<ControlInOut>> GetByRange(DateTime pDate)
	{
		return await _context.ControlInOut
			.AsNoTracking()
			.Where(x => x.DateTimeIn >= pDate && (x.DateTimeOut == null || x.DateTimeOut >= pDate))
			.Include(v => v.VehicleType)
			.Include(a => a.AccordType)
			.OrderBy(x => x.DateTimeIn)
			.ToListAsync();
	}

	public void Dispose()
	{
		_context?.Dispose();
	}



}
