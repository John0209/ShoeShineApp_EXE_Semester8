using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetById(Guid id);
		Task<T> GetById(int id);
		Task<List<T>> GetAll();
		Task Add(T entity);
		Task AddList(List<T> entities);
		void Remove(T entity);
		void Update(T entity);
	}
}
