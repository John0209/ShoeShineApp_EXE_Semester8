using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingService _booking;
        IMapper _map;

        public BookingController(IBookingService booking, IMapper map)
        {
            _booking = booking;
            _map = map;
        }
        [HttpGet()]
        public async Task<IActionResult> GetBooking()
        {
            var booking = await _booking.GetBookingAsync();
            if (booking != null)
            {
                var respone = _map.Map<IEnumerable<BookingRespone>>(booking);
                return Ok(respone);
            }
            return BadRequest("Booking Empty!");
        }
        [HttpPatch()]
        public async Task<IActionResult> UpdateBooking()
        {
            var booking = await _booking.GetBookingJustCreate();
            if (booking >0)
            {
                if (await _booking.UpdateStatusBooking(booking)) return Ok("Update Status Success");
            }
            return NotFound("No Status 0 Exist");
        }
        [HttpPost()]
        public async Task<IActionResult> CreateBooking(BookingRequest request)
        {
            var booking = _map.Map<Booking>(request);
            var result = await _booking.CreateBooking(booking,request.CategoryIdArray);
            if (result) return Ok("Create Booking Success");
            return BadRequest("Create Booking Fail");
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoveAllBookings()
        {
            await _booking.RemoveAllBookings();
            return NoContent();
        }
    }
}
