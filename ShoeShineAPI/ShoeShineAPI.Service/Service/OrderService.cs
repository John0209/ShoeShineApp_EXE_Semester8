using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class OrderService : CommonAbstract<Order>, IOrderService
    {
        IUnitRepository _unit;
        IOrderDetailService _orderDetail;

        public OrderService(IUnitRepository unit, IOrderDetailService orderDetail)
        {
            _unit = unit;
            _orderDetail = orderDetail;
        }

        public async Task<bool> CreateOrder(Order order, OrderRequest request)
        {
            var orders= await GetAllDataAsync();
            order.OrderCode = GenerateOrderCode(orders);
            await _unit.OrderRepository.Add(order);
            int result= _unit.Save();
            if (result > 0)
            {
                request.OrderId = order.OrderId;
                if(await _orderDetail.CreateOrderDetail(request)) return true;
            }
            return false;
        }

        private string GenerateOrderCode(IEnumerable<Order> orders)
        {
            while (true)
            {
                string code = "O";
                Random rd = new Random();
                int number = rd.Next(1000, 9999);
                code += number;
                var result = _unit.OrderRepository.CheckOrderCode(code, orders);
                if (result) return code;
            }
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
