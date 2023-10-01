using ShoeShineAPI.Core.Model;
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
        Task<string> RegisterStoreAsync(StoreRegistrationRespone storeRegister);
        Task<bool> CheckStoreEmailExistsAsync(string storeEmail);
        Task<Store> GetStoreById(int id);
    }
}
