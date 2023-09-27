using ShoeShineAPI.Core.EntityModel;
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
    }
}
