namespace RS.Parking.Infrastructure.Contracts;

public interface ICoreRepository
{
	void Add<T>(T entity) where T : class;
	void Update<T>(T entity) where T : class;
	void Delete<T>(T entity) where T : class;
	Task<bool> SaveChangesAsync();
}
