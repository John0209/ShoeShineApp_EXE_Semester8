using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
    public interface IOrderDetailService
    {
        public Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync();
        public Task<bool> CreateOrderDetail(OrderRequest request);
    }
}
