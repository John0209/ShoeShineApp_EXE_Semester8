using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
	public class ServiceStoreRepository : GenericRepository<ServiceStoreEntity>, IServiceStoreRepository
	{
		public ServiceStoreRepository(DbContextClass context) : base(context)
		{
		}

		public IEnumerable<int> GetServiceIdByStoreId(int storeId)
		{
			return _dbContext.Set<ServiceStoreEntity>().Where(x=> x.StoreId == storeId).Select(x=> x.ServiceId);
		}
	}
}
