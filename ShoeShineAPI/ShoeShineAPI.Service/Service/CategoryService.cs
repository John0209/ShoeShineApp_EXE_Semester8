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
		ICategoryStoreService _categoryStore;

        public CategoryService(IUnitRepository unit, ICategoryStoreService categoryStore)
        {
            _unit = unit;
            _categoryStore = categoryStore;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			var categories = await GetAllDataAsync();
			return categories;
		}

		//public async Task<IEnumerable<Category>> GetCategoriesByStoreId(IEnumerable<CategoryStore> categoryStores, int storeId)
		//{
		//	// lấy những categoryId có trong list categoryStores bằng storeId truyển vào
		//	var matchingCategoryId = categoryStores.Where(x => x.StoreId == storeId).Select(x => x.CategoryId);
		//	// sau khi có list categoryId lọc ra bởi storeId, ta lấy ra list category 
		//	var categories = await GetAllDataAsync();
		//	var categoriesOfStore = GetMatchingItems(matchingCategoryId, categories, x => x.CategoryId);
		//	if (categoriesOfStore != null)
		//		return categoriesOfStore;
		//	else
		//		return Enumerable.Empty<Category>();
		//}
		public bool AddCategory(string categoryName)
		{
			var category = new Category();
			category.CategoryName=categoryName;
			category.IsCategoryStatus = true;
			_unit.CategoryRepository.Add(category);
			var result = _unit.Save();
			if (result > 0) return true;
			return false;
		}
		protected override async Task<IEnumerable<Category>> GetAllDataAsync()
		{
			return await _unit.CategoryRepository.GetAll();
		}

		public async Task RemoveAllCategories()
		{
			var categories = await _unit.CategoryRepository.GetAll();
			if(categories != null && categories.Any())
			{
				var bookingCategories = await _unit.BookingCategoryRepository.GetAll();
				if(bookingCategories != null && bookingCategories.Any())
				{
					_unit.BookingCategoryRepository.RemoveRange(bookingCategories);
				}

				var categoryStore = await _unit.CategoryStoreRepository.GetAll();
				if(categoryStore != null && categoryStore.Any())
				{
					_unit.CategoryStoreRepository.RemoveRange(categoryStore);
				}

				var products = await _unit.ProductRepository.GetAll();
				if(products != null && products.Any())
				{
					_unit.ProductRepository.RemoveRange(products);
				}

				_unit.CategoryRepository.RemoveRange(categories);
				_unit.Save();
			}
		}
        public async Task<List<CategoryStore>> GetCategoryByStoreId(int storeId)
        {
            List<CategoryStore> list = new List<CategoryStore>();
            var categoryStoreIdList = _categoryStore.GetCateogryStoreId(storeId);
            if (categoryStoreIdList.Any())
            {
                foreach (var x in categoryStoreIdList)
                {
                    var categoryStore = new CategoryStore();
                    categoryStore = await _categoryStore.GetCategoryStoreById(x);
                    if (categoryStore != null) list.Add(categoryStore);
                }
            }
            return list;
        }

    }
}
