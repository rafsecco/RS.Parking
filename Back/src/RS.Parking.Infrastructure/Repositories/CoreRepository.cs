using RS.Parking.Infrastructure.Contexts;
using RS.Parking.Infrastructure.Contracts;

namespace RS.Parking.Infrastructure.Repositories;

public class CoreRepository : ICoreRepository
{
	private readonly RSParkingContext _context;

	public CoreRepository(RSParkingContext context)
	{
		_context = context;
	}

	public void Add<T>(T entity) where T : class
	{
		_context.Add(entity);
	}

	public void Update<T>(T entity) where T : class
	{
		_context.Update(entity);
	}

	public void Delete<T>(T entity) where T : class
	{
		_context.Remove(entity);
	}

	public async Task<bool> SaveChangesAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}
}
