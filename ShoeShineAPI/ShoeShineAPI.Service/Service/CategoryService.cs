using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
	public class CategoryService : CommonAbstract<Category>, ICategoryService
	{
		IUnitRepository _unit;

		public CategoryService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			var categories = await GetAllDataAsync();
			return categories;
		}

		public async Task<IEnumerable<Category>> GetCategoriesByStoreId(IEnumerable<CategoryStore> categoryStores, int storeId)
		{
			// lấy những categoryId có trong list categoryStores bằng storeId truyển vào
			var matchingCategoryId = categoryStores.Where(x => x.StoreId == storeId).Select(x => x.CategoryId);
			// sau khi có list categoryId lọc ra bởi storeId, ta lấy ra list category 
			var categories = await GetAllDataAsync();
			var categoriesOfStore = GetMatchingItems(matchingCategoryId, categories, x => x.CategoryId);
			if (categoriesOfStore != null)
				return categoriesOfStore;
			else
				return Enumerable.Empty<Category>();
		}

		protected override async Task<IEnumerable<Category>> GetAllDataAsync()
		{
			return await _unit.CategoryRepository.GetAll();
		}
	}
}
