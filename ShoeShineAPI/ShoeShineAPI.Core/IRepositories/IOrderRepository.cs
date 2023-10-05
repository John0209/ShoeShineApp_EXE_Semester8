using ShoeShineAPI.Core.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        public bool CheckOrderCode(string orderCode,IEnumerable<Order> orders);
        public Task<Order?> GetOrderStatusPayment();
        public Task<Order?> GetOrderByOrderCode(string orderCode);
    }
}
