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
            var checkOrder = await GetOrderStatusPayment();
            // check xem có order nào ở status payment không, nếu có thì phải thanh toán xong mới được tạo típ order
            if (checkOrder == null)
            {
                var orders = await GetAllDataAsync();
                order.OrderCode = GenerateOrderCode(orders);
                order.IsOrderStatus = 0;
                //order.OrderDate = DateTime.Now;
                await _unit.OrderRepository.Add(order);
                int result = _unit.Save();
                if (result > 0)
                {
                    request.OrderId = order.OrderId;
                    if (await _orderDetail.CreateOrderDetail(request)) return true;
                }
            }
            return false;
        }
        public async Task<Order?> GetOrderStatusPayment()
        {
            return await _unit.OrderRepository.GetOrderStatusPayment();
        }
        public async Task<bool> UpdateOrderAfterPaymentSuccess(string orderCode)
        {
            var order = await _unit.OrderRepository.GetOrderByOrderCode(orderCode);
            if (order != null)
            {
                order.IsOrderStatus = 1;
                _unit.OrderRepository.Update(order);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        public async Task<bool> UpdateOrderShippingStatus(string orderCode)
        {
            var order = await _unit.OrderRepository.GetOrderByOrderCode(orderCode);

            if (order != null)
            {
                if (order.IsOrderStatus == 1)
                {
                    order.IsOrderStatus = 2;

                    _unit.OrderRepository.Update(order);
                    var result = _unit.Save();

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public async Task<bool> UpdateOrderStatusToReceived(string orderCode)
        {
            var order = await _unit.OrderRepository.GetOrderByOrderCode(orderCode);

            if (order != null)
            {
                if (order.IsOrderStatus == 2) // Check if the order is in the "Shipped" status.
                {
                    order.IsOrderStatus = 3; // Update the order status to "Received."

                    _unit.OrderRepository.Update(order);
                    var result = _unit.Save();

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<bool> CancelOrder(string orderCode)
        {
            var order = await _unit.OrderRepository.GetOrderByOrderCode(orderCode);

            if (order != null)
            {
                if (order.IsOrderStatus == 0 || order.IsOrderStatus == 1)
                {
                    // Set the order status to "Canceled" for orders in "Await Payment" or "Confirmed" status.
                    order.IsOrderStatus = 4; // Update the order status to "Canceled."

                    _unit.OrderRepository.Update(order);
                    var result = _unit.Save();

                    if (result > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        private string GenerateOrderCode(IEnumerable<Order> orders)
        {
            while (true)
            {
                string code = "SSN-";
                Random rd = new Random();
                int number = rd.Next(1000, 9999);
                code += number;
                var result = _unit.OrderRepository.CheckOrderCode(code, orders);
                if (result) return code;
            }
        }
        public async Task<Order?> GetOrderShippingPayment()
        {
            return await _unit.OrderRepository.GetOrderShippingPayment();
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _unit.OrderRepository.GetById(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await GetAllDataAsync();
        }

        protected override async Task<IEnumerable<Order>> GetAllDataAsync()
        {
            return await _unit.OrderRepository.GetAll();
        }

        public async Task RemoveAllOrders()
        {
            var orders = await _unit.OrderRepository.GetAll();
            if(orders != null && orders.Any())
            {
                var orderDetails = await _unit.OrderDetailRepository.GetAll();
                if(orderDetails != null && orderDetails.Any())
                {
                    _unit.OrderDetailRepository.RemoveRange(orderDetails);
                }
                _unit.OrderRepository.RemoveRange(orders);
                _unit.Save();
            }
        }
    }
}
