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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContextClass context) : base(context)
        {
        }
    }
}
