using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T?> GetById(Guid id);
		Task<T?> GetById(int id);
		Task<IEnumerable<T>> GetAll();
		Task Add(T entity);
		Task AddList(IEnumerable<T> entities);
		void Remove(T entity);
		void Update(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
