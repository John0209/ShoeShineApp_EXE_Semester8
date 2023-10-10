using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
    public class ServicePriceRepository : GenericRepository<ServicePrice>, IServicePriceRepository
    {
        public ServicePriceRepository(DbContextClass context) : base(context)
        {
        }
        public override Task<ServicePrice?> GetById(int id)
        {
            return _dbContext.Set<ServicePrice>().Where(x=> x.ServiceStoreId == id).FirstOrDefaultAsync();
        }
    }
}
