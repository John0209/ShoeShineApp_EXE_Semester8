using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrdersAsync();
        public Task<bool> CreateOrder(Order orderRequest, OrderRequest request);
        public Task<Order> GetOrderById(int orderId);
    }
}
