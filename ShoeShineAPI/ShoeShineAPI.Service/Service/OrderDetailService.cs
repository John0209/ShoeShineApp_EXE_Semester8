using EllipticCurve.Utils;
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
    public class OrderDetailService :CommonAbstract<OrderDetail>, IOrderDetailService
    {
        IUnitRepository _unit;
        IBookingService _booking;

        public OrderDetailService(IUnitRepository unit, IBookingService booking)
        {
            _unit = unit;
            _booking = booking;
        }

        protected override async Task<IEnumerable<OrderDetail>> GetAllDataAsync()
        {
            return await _unit.OrderDetailRepository.GetAll();
        }

        public async Task<bool> CreateOrderDetail(OrderRequest request)
        {
            OrderDetail orderDetail = new OrderDetail();
            // nếu lấy đươc bookingid vừa tạo, thì update lại nó thành status 2, status 1 là just create
            orderDetail.BookingId = await _booking.GetBookingJustCreate();
            if (orderDetail.BookingId > 0)
            {
                await _booking.UpdateStatusBooking(orderDetail.BookingId);
                // lấy orderId vừa tạo
                orderDetail.OrderId = request.OrderId;
                orderDetail.QuantityItem = request.QuantityItem;
                orderDetail.ShipFee = request.Shipfee;
                await _unit.OrderDetailRepository.Add(orderDetail);
                int result = _unit.Save();
                if (result > 0) return true;
            } 
            return false;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync()
        {
            return await GetAllDataAsync();
        }
    }
}
