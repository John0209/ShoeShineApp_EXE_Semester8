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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContextClass context) : base(context)
        {
        }

        public Task<Order?> GetOrderStatusPayment()
        {
            return _dbContext.Set<Order>().Where(x => x.IsOrderStatus == 0).FirstOrDefaultAsync();
        }
        
        public Task<Order?> GetOrderShippingPayment()
        {
            return _dbContext.Set<Order>().Where(x => x.IsOrderStatus == 2).FirstOrDefaultAsync();
        }
        public bool CheckOrderCode(string orderCode, IEnumerable<Order> orders)
        {
            var result = orders.Where(x => x.OrderCode.ToLower().CompareTo(orderCode.ToLower().Trim()) == 0).ToList();
            if (result.Count > 0) return false;
            return true;
        }
        public Task<Order?> GetOrderByOrderCode(string orderCode)
        {
            return _dbContext.Set<Order>().Where(x => x.OrderCode == orderCode).FirstOrDefaultAsync();
        }
        public override async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Set<Order>().Include(x => x.User).ToListAsync();
        }

    }
}
