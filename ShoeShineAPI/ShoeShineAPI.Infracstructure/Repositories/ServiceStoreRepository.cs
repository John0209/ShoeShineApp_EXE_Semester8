using Microsoft.EntityFrameworkCore;
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
	public class ServiceStoreRepository : GenericRepository<ServiceStore>, IServiceStoreRepository
	{
		public ServiceStoreRepository(DbContextClass context) : base(context)
		{
		}

		public List<int> GetServiceStoreId(int storeId)
		{
			return _dbContext.Set<ServiceStore>().Where(x=> x.StoreId == storeId).Select(x=> x.ServiceStoreId).ToList();
		}
        public override Task<ServiceStore?> GetById(int id)
        {
            return _dbContext.Set<ServiceStore>().Where(x => x.ServiceStoreId == id)
                            .Include(x => x.Service).Include(x => x.Store).Include(x=> x.ServicePrice).FirstOrDefaultAsync();
        }
        public Task<ServiceStore?> CheckServiceStoreExist(int storeId, int serviceId)
		{
			return _dbContext.Set<ServiceStore>().Where(x => x.StoreId == storeId && x.ServiceId==serviceId)
				.FirstOrDefaultAsync();
        }

        public Task<ServiceStore?> GetByServiceId(int serviceId, int storeId)
        {
            return _dbContext.Set<ServiceStore>().Where(x => x.ServiceId == serviceId && x.StoreId==storeId)
                             .Include(x => x.Service).Include(x => x.Store).Include(x => x.ServicePrice).FirstOrDefaultAsync();
        }
    }
}
