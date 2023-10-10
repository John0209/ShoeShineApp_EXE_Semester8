using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
	public class CategoryStoreRepository : GenericRepository<CategoryStore>, ICategoryStoreRepository
	{
		public CategoryStoreRepository(DbContextClass context) : base(context)
		{
		}
        public List<int> GetCategoryStoreId(int storeId)
        {
            return _dbContext.Set<CategoryStore>().Where(x => x.StoreId == storeId).Select(x => x.CategoryStoreId).ToList();
        }
        public override Task<CategoryStore?> GetById(int id)
        {
            return _dbContext.Set<CategoryStore>().Where(x => x.CategoryStoreId == id)
                            .Include(x => x.Category).Include(x => x.Store).FirstOrDefaultAsync();
        }
        public Task<CategoryStore?> CheckCategoryStoreExist(int storeId, int categoryId)
        {
            return _dbContext.Set<CategoryStore>().Where(x => x.StoreId == storeId && x.CategoryId == categoryId)
                .FirstOrDefaultAsync();
        }
    }
}
