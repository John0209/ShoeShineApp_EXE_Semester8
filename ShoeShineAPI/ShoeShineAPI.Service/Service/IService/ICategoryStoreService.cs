using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface ICategoryStoreService
	{
		public Task<IEnumerable<CategoryStore>> GetCategoriesStoreAsync();
		public  Task<(bool, string)> AddCategoryStore(int storeId, int[] categoryArray);
		public  Task<bool> UpdateCategoryStore(CategoryStore? categoryStore, int storeId, int[] categoryArray, bool isCheck);
		public List<int> GetCateogryStoreId(int storeId);
		public  Task<CategoryStore?> GetCategoryStoreById(int categoryStoreId);

    }
}
