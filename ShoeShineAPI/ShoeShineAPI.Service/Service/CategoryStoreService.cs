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
	public class CategoryStoreService : CommonAbstract<CategoryStore>, ICategoryStoreService
	{
		IUnitRepository _unit;

		public CategoryStoreService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public async Task<IEnumerable<CategoryStore>> GetCategoriesStoreAsync()
		{
			var categories= await GetAllDataAsync();
			return categories;
		}

		protected override async Task<IEnumerable<CategoryStore>> GetAllDataAsync()
		{
			return await _unit.CategoryStoreRepository.GetAll();
		}
        public async Task<bool> CreateCategoriesStore(int storeId, int[] categoriesArray)
        {
            if (categoriesArray.Length > 0 && storeId > 0)
            {
                foreach (var categoryId in categoriesArray)
                {
                    var categoriesStore = new CategoryStore();
                    categoriesStore.StoreId = storeId;
                    categoriesStore.CategoryId = categoryId;
                    await _unit.CategoryStoreRepository.Add(categoriesStore);
                    _unit.Save();
                }
                return true;
            }
            return false;
        }
    }
}
