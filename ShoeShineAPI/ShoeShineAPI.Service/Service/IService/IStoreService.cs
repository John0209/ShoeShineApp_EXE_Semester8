using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface IStoreService
	{
		public Task<IEnumerable<Store>> GetStoresAsync();
        public Task<(bool, string)> RegisterStoreAsync(Store store, StoreRequest request);
        Task<bool> CheckStoreEmailExistsAsync(string storeEmail);
        Task<Store?> GetStoreById(int id);
        Task<IEnumerable<Store>> GetStoreByName(string storeName);
        void UpdateStore(Store store);
        Task RemoveAllStores();
    }
}
