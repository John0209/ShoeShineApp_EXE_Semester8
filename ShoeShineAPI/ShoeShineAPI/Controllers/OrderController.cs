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
            var orders=await _order.GetOrdersAsync();
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
            var respone= await this._order.CreateOrder(_order,request);
            if (respone) return Ok("Create Order Success");
            return BadRequest("Create Order Fail");
        }
    }
}
