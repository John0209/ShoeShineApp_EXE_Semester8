using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class OrderService : CommonAbstract<Order>, IOrderService
    {
        IUnitRepository _unit;

        public OrderService(IUnitRepository uni)
        {
            _unit = uni;
        }

        public async Task<bool> CreateOrder(Order orderRequest)
        {
            await _unit.OrderRepository.Add(orderRequest);
            int result= _unit.Save();
            if(result>0) return true;
            return false;
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _unit.OrderRepository.GetById(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await GetAllDataAsync();
        }

        protected  override async Task<IEnumerable<Order>> GetAllDataAsync()
        {
            return await _unit.OrderRepository.GetAll();
        }
    }
}
