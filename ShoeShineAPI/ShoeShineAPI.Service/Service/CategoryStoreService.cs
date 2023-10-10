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
        public async Task<(bool, string)> AddCategoryStore(int storeId, int[] categoryArray)
        {
            if (categoryArray.Length > 0 && storeId > 0)
            {
                foreach (var categoryId in categoryArray)
                {
                    var checkStatus = await _unit.CategoryStoreRepository.CheckCategoryStoreExist(storeId, categoryId);
                    if (checkStatus == null)
                    {
                        var categoryStore = new CategoryStore();
                        categoryStore.StoreId = storeId;
                        categoryStore.CategoryId = categoryId;
                        categoryStore.IsCategoryStoreStatus = true;
                        await _unit.CategoryStoreRepository.Add(categoryStore);
                        if (_unit.Save() == 0) return (false, "Error When Add StoreId=" + storeId);
                    }
                    else
                    {
                        var result = await UpdateCategoryStore(checkStatus, 0, Array.Empty<int>(), true);
                        if (!result) return (false, "Error When Update Status StoreId=" + storeId);
                    }
                }
                return (true, "Add ServiceStore Success");
            }
            return (false, "Add ServiceStore Fail");
        }
        public async Task<bool> UpdateCategoryStore(CategoryStore? categoryStore, int storeId, int[] categoryArray, bool isCheck)
        {
            switch (isCheck)
            {
                case true:
                    if (categoryStore != null)
                    {
                        categoryStore.IsCategoryStoreStatus = isCheck;
                        _unit.CategoryStoreRepository.Update(categoryStore);
                        if (_unit.Save() > 0)
                            return true;
                    }
                    break;
                case false:
                    if (categoryArray.Length > 0 && storeId > 0)
                    {
                        foreach (var categoryId in categoryArray)
                        {
                            var _categoryStore = await _unit.CategoryStoreRepository.CheckCategoryStoreExist(storeId, categoryId);
                            if (_categoryStore != null)
                            {
                                _categoryStore.IsCategoryStoreStatus = isCheck;
                                _unit.CategoryStoreRepository.Update(_categoryStore);
                                if (_unit.Save() == 0) return false;
                            }
                        }
                        return true;
                    }
                    break;
            }
            return false;
        }
        public List<int> GetCateogryStoreId(int storeId)
        {
            return _unit.CategoryStoreRepository.GetCategoryStoreId(storeId);
        }
        public async Task<CategoryStore?> GetCategoryStoreById(int categoryStoreId)
        {
            return await _unit.CategoryStoreRepository.GetById(categoryStoreId);
        }

    }
}
