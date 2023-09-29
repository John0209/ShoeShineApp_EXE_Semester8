using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
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

		public StoreService(IUnitRepository unit)
		{
			_unit = unit;
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
        public async Task<string> RegisterStoreAsync(StoreRegistrationRespone storeRegister)
        {
            if (await CheckStoreEmailExistsAsync(storeRegister.StoreEmail))
            {
                return "StoreEmail already exists";
            }

            var newRating = new Rating
            {
                RatingScale = 0
            };

            await _unit.RatingRepository.Add(newRating);
             _unit.Save(); 

            var newStore = new Store
            {
                StoreName = storeRegister.StoreName,
                StoreAddress = storeRegister.StoreAddress,
                StorePhone = storeRegister.StorePhone,
                StoreEmal = storeRegister.StoreEmail,
                RatingId = newRating.RatingId 
            };

            // Save the new store to the database
            await _unit.StoreRepository.Add(newStore);
             _unit.Save(); // Assuming SaveAsync saves changes to the database

            return "Store registration successful";
        }

        public async Task<bool> CheckStoreEmailExistsAsync(string storeEmail)
        {

            var stores = await GetAllDataAsync(); 
            return stores.Any(s => s.StoreEmal == storeEmail);
        }

    }
}
