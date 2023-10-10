using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
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
       
        [HttpGet()]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _order.GetOrdersAsync();
            if (orders.Any())
            {
                var orderRespone = _map.Map<IEnumerable<OrderRespone>>(orders);
                return Ok(orderRespone);
            }
            return BadRequest("Order is empty!");
        }
        [HttpPost()]
        public async Task<IActionResult> CreateOrder(OrderRequest request)
        {
            var _order = _map.Map<Order>(request);
            var respone = await this._order.CreateOrder(_order, request);
            if (respone) return Ok("Create Order Success");
            return BadRequest("Create Order Fail");
        }

        [HttpPatch("shipping/{orderCode}")]
        public async Task<IActionResult> UpdateShippingStatus(string orderCode)
        {
            if (await _order.UpdateOrderShippingStatus(orderCode))
            {
                return Ok("Order has updated status Confirm to Shipping successfully.");
            }

            return BadRequest("Failed to update order shipping status.");
        }
        [HttpPatch("received/{orderCode}")]
        public async Task<IActionResult> UpdateOrderStatusToReceived( string orderCode)
        {
            var success = await _order.UpdateOrderStatusToReceived(orderCode);
            if (success)
            {
                return Ok("Order status updated to 'Received' successfully.");
            }
            return BadRequest("Failed to update order status.");
        }

        [HttpPatch("cancel/{orderCode}")]
        public async Task<IActionResult> CancelOrder(string orderCode)
        {
            var success = await _order.CancelOrder(orderCode);
            if (success)
            {
                return Ok("Order has been canceled successfully.");
            }
            return BadRequest("Failed to cancel the order.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAllOrders()
        {
            await _order.RemoveAllOrders();
            return NoContent();
        }

    }
}
