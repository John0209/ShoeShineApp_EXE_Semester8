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
		public Task<bool> CreateCategoriesStore(int storeId, int[] categoriesArray);

    }
}
