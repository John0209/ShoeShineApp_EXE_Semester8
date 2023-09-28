using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
    [Route("api/order-details")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        IOrderDetailService _orderDetail;
        IMapper _map;
        public OrderDetailController(IOrderDetailService orderDetail, IMapper map)
        {
            _orderDetail = orderDetail;
            _map = map;
        }
        [HttpGet()]
        public async Task<IActionResult> GetOrderDetails()
        {
            var orderDetail= await _orderDetail.GetOrderDetailsAsync();
            if(orderDetail != null)
            {
                var respone = _map.Map<ICollection<OrderDetailRespone>>(orderDetail);
                return Ok(respone);
            }
            return BadRequest("OrderDetail Empty!");
        }
    }
}
