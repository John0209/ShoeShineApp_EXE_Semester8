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
		public Task<IEnumerable<Category>> GetCategoriesByStoreId(IEnumerable<CategoryStore> categoryStores, int storeId);
		public Task<IEnumerable<Category>> GetCategoriesAsync();
		public Task RemoveAllCategories();
	}
}
