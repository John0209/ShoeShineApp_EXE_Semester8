using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface IServiceStoreService
	{
		public Task<IEnumerable<ServiceStore>> GetServiceStoreAsync();
		public  Task<ServiceStore?> GetServiceStoreById(int serviceStoreId);
		public List<int> GetServiceStoreId(int storeId);

        public Task<(bool, string)> AddServiceStore(int storeId, int[] serviceArray, float[] price);
		public Task<bool> UpdateServiceStore(float price, ServiceStore? serviceStore, int storeId, int[] serviceArray, bool isCheck);
    }
}
