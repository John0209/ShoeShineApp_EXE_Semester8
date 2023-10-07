using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
	public class StoreService : CommonAbstract<Store>, IStoreService
	{
		IUnitRepository _unit;
        IServiceStoreService _service;
        ICategoryStoreService _category;
        IImageStoreService _image;

        public StoreService(IUnitRepository unit, IServiceStoreService service, ICategoryStoreService category, 
            IImageStoreService image)
        {
            _unit = unit;
            _service = service;
            _category = category;
            _image = image;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
		{
			var stores= await GetAllDataAsync();
			return stores;
		}

		protected override async Task<IEnumerable<Core.Model.Store>> GetAllDataAsync()
		{
			return await _unit.StoreRepository.GetAll();
		}
        public async Task<(bool,string)> RegisterStoreAsync(Store store,StoreRequest request)
        {
            if (await CheckStoreEmailExistsAsync(store.StoreEmal))
            {
                return (false, "StoreEmail already exists");
            }
            // Save the new store to the database
            await _unit.StoreRepository.Add(store);
            var result= _unit.Save();
            if (result > 0)
            {
                if(await _category.CreateCategoriesStore(store.StoreId, request.CategoryArray))
                {
                   if(await _service.CreateServiceStore(store.StoreId, request.ServiceArray))
                    {
                        if(await _image.CraeteImageStore(store.StoreId, request.Url)){
                            return (true, "Create Store Success");
                        }
                        return (false, "Create ImageStore Fail");
                    }
                   return (false, "Create ServiceStore Fail");
                }
                return (false, "Create CategoriesStore Fail");
            }
            return (false, "Create Store Fail");
        }

        public async Task<bool> CheckStoreEmailExistsAsync(string storeEmail)
        {

            var stores = await GetAllDataAsync(); 
            return stores.Any(s => s.StoreEmal == storeEmail);
        }

        public async Task<Store?> GetStoreById(int id)
        {
            var store = await _unit.StoreRepository.GetById(id);
            return store;
        }

        public async Task<IEnumerable<Store>> GetStoreByName(string storeName)
        {
            var stores = await _unit.StoreRepository.GetStoresByName(storeName);
            return stores;
        }

        public void UpdateStore(Store store)
        {
            _unit.StoreRepository.Update(store);
            _unit.Save();
        }

        public async Task RemoveAllStores()
        {
            var stores = await _unit.StoreRepository.GetAll();
            if (stores.Any())
            {
                var serviceStores = await _unit.ServiceStoreRepository.GetAll();
                if (serviceStores.Any())
                {
                    _unit.ServiceStoreRepository.RemoveRange(serviceStores);
                }
                _unit.StoreRepository.RemoveRange(stores);
                _unit.Save();
            }
        }
    }
}
