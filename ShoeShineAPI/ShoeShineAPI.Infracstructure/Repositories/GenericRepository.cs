using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly DbContextClass _dbContext;
		protected GenericRepository(DbContextClass context)
		{
			_dbContext = context;
		}
		public async Task Add(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
		}

		public async Task AddList(IEnumerable<T> entities)
		{
			await _dbContext.Set<T>().AddRangeAsync(entities);
		}

		public void Remove(T entity)
		{
			 _dbContext.Set<T>().Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await _dbContext.Set<T>().ToListAsync();
		}

		public async Task<T> GetById(Guid id)
		{
			T? entity = await _dbContext.Set<T>().FindAsync(id);
			if (entity == null)
			{
				// Xử lý khi không tìm thấy đối tượng
				throw new NullReferenceException();
			}
			return entity;
		}

		public async Task<T> GetById(int id)
		{
			T? entity = await _dbContext.Set<T>().FindAsync(id);
			if (entity == null)
			{
				// Xử lý khi không tìm thấy đối tượng
				throw new NullReferenceException();
			}
			return entity;
		}

		public void Update(T entity)
		{
			_dbContext.Set<T>().Update(entity);
		}
	}
}
