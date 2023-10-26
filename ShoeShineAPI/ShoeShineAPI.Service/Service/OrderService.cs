using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
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
                order.OrderDate = DateTime.Now;
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
        private async Task<bool> UpdateStatus(string orderCode, int statusCheck, int statusUpdate)
        {
            var order = await _unit.OrderRepository.GetOrderByOrderCode(orderCode);
            if (order != null && order.IsOrderStatus==statusCheck)
            {
                order.IsOrderStatus = statusUpdate;
                _unit.OrderRepository.Update(order);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        public async Task<bool> UpdateOrderAfterPaymentSuccess(string orderCode)
        {
            // Check if the order is in the "Payment-0" status, after update status "Confirm-1"
            return await UpdateStatus(orderCode, 0, 1);
        }
        public async Task<bool> UpdateOrderShippingStatus(string orderCode)
        {
            // Check if the order is in the "Confirmed-1" status, after update status "Shipped-2"
            return await UpdateStatus(orderCode, 1, 2);
        }
        public async Task<bool> UpdateOrderStatusToReceived(string orderCode)
        {
            // Check if the order is in the "Shipped-2" status, after update status "Received-3"
            return await UpdateStatus(orderCode, 2, 3);
        }
        public async Task<bool> CancelOrder(string orderCode)
        {
            // Check if the order is in the "Payment-0" or "Confirmed-1" status, after update status "Canceled-4"
            if (!await UpdateStatus(orderCode, 0, 4)) 
            { 
                if(await UpdateStatus(orderCode, 1, 4)) 
                    return true; 
                return false;
            }
            return true;
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
        public bool AddPaymentMethod(string nameMethod)
        {
            var pay = new PaymentMethod();
            pay.MethodName = nameMethod;
            pay.IsStatusMethod = true;
            _unit.PaymentMethodRepository.Add(pay);
            var result = _unit.Save();
            if (result > 0) return true;
            return false;
        }

    }
}
