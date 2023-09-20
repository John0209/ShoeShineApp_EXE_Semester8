using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDB = ShoeShineAPI.Core.Model.ServiceEntity;
namespace ShoeShineAPI.Service.Service.IService
{
	public interface IServiceService
	{
		public Task<IEnumerable<ServiceDB>> GetServicesByStoreId(IEnumerable<ServiceStoreEntity> serviceStores, int storeId);
		public Task<IEnumerable<ServiceDB>> GetServicesAsync();
	}
}
