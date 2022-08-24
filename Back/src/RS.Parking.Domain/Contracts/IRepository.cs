using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Parking.Domain.Contracts
{
	public interface IRepository<TEntity> : IDisposable
    {
		Task<List<TEntity>> GetAll();

		Task<TEntity> GetById(ushort id);

		Task<int> Add(TEntity entity);

		Task<int> Update(TEntity entity);

		Task<int> Remove(TEntity entity);
    }
}
