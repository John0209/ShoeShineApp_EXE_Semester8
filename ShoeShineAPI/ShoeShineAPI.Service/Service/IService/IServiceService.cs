using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDB = ShoeShineAPI.Core.Model.Service;
namespace ShoeShineAPI.Service.Service.IService
{
	public interface IServiceService
	{
		//public Task<IEnumerable<ServiceDB>> GetCategoryByStoreId(IEnumerable<ServiceStore> serviceStores, int storeId);
		public  Task<List<ServiceStore>> GetServicesByStoreId(int storeId);

        public Task<IEnumerable<ServiceDB>> GetServicesAsync();
		public Task RemoveAllServices();
	}
}
