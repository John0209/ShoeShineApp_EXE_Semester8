using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface ICategoryStoreRepository:IGenericRepository<CategoryStore>
	{
        public Task<CategoryStore?> CheckCategoryStoreExist(int storeId, int categoryId);
        public List<int> GetCategoryStoreId(int storeId);
    }
}
