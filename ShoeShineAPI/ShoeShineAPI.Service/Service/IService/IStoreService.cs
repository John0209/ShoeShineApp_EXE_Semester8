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
        Task<bool> CheckStoreEmailExistsAsync(string storeEmail, int storeId);
        Task<IEnumerable<Store>> GetStoreByName(string storeName);
        public Task<(bool, string)> UpdateStore(Store request, string[] url);
        Task RemoveAllStores();
        public Task<Store?> GetStoreById(int storeId);
    }
}
