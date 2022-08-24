using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Contracts;

namespace RS.Parking.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
	protected readonly RSParkingContext Db;
	protected readonly DbSet<TEntity> DbSet;

	public Repository(RSParkingContext db)
	{
		Db = db;
		DbSet = db.Set<TEntity>();
	}

	public virtual async Task<List<TEntity>> GetAll()
	{
		return await DbSet.ToListAsync();
	}

	public virtual async Task<TEntity> GetById(ushort id)
	{
		return await DbSet.FindAsync(id);
	}

	public virtual async Task<int> Add(TEntity entity)
	{
		DbSet.Add(entity);
		return await SaveChanges();
	}

	public virtual async Task<int> Update(TEntity entity)
	{
		DbSet.Update(entity);
		return await SaveChanges();
	}

	public virtual async Task<int> Remove(TEntity entity)
	{
		DbSet.Remove(entity);
		return await SaveChanges();
	}

	public async Task<int> SaveChanges()
	{
		return await Db.SaveChangesAsync();
	}

	public void Dispose()
	{
		Db?.Dispose();
	}
}
