using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface ICategoryService
	{
		public Task<IEnumerable<CategoryEntity>> GetCategoriesByStoreId(IEnumerable<CategoryStoreEntity> categoryStores, int storeId);
		public Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
	}
}
