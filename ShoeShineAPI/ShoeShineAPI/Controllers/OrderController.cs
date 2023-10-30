using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Enum;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _order;
        IMapper _map;

        public OrderController(IOrderService order, IMapper map)
        {
            _order = order;
            _map = map;
        }
        /// <summary>
        /// Add Payment Method
        /// </summary>
        /// <param name="nameMethod"></param>
        /// <returns></returns>
        [HttpPost("payment")]
        public IActionResult AddRating(string nameMethod)
        {
            var result = _order.AddPaymentMethod(nameMethod);
            if (result) return Ok("Add Method Successfully");
            return BadRequest("Add Method Failed");
        }
        [HttpGet()]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _order.GetOrdersAsync();
            if (orders.Any())
            {
                var orderRespone = _map.Map<IEnumerable<OrderRespone>>(orders);
                return Ok(orderRespone);
            }
            return NotFound("List of Order is Empty");
        }
        [HttpPost()]
        public async Task<IActionResult> CreateOrder(OrderRequest request)
        {
            var _order = _map.Map<Order>(request);
            var respone = await this._order.CreateOrder(_order, request);
            if (respone) return Ok("Order Created Successfully");
            return BadRequest("Order Creation Failed");
        }
        /// <summary>
        /// Update Order Status
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="status">1.Confirm, 2.Shipping, 3.Receive, 4.Cancel</param>
        /// <returns></returns>
        [HttpPatch("{orderCode}")]
        public async Task<IActionResult> UpdateOrderStatusToReceived(string orderCode,EnumClass.OrderStatus status)
        {
            bool result = true;
            switch ((int)status)
            {
                case 1:
                    result= await _order.UpdateOrderAfterPaymentSuccess(orderCode);
                    break;
                case 3:
                    result= await _order.UpdateOrderStatusToReceived(orderCode);
                    break;
                case 2:
                    result = await _order.UpdateOrderShippingStatus(orderCode);
                    break;
                case 4:
                    result= await _order.CancelOrder(orderCode);
                    break;
            }
            if (result)
            {
                return Ok("Order Status Updated To "+status+" Successfully");
            }
            return BadRequest("Failed to update order status "+status);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAllOrders()
        {
            await _order.RemoveAllOrders();
            return NoContent();
        }

    }
}
