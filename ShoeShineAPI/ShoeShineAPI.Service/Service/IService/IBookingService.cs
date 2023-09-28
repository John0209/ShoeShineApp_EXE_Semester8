using ShoeShineAPI.Core.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
    public interface IBookingService
    {
        public Task<IEnumerable<Booking>> GetBookingAsync();
        public Task<bool> CreateBooking(Booking booking);
        public Task<int> GetBookingIdByStatus2();
        public Task<Booking> GetBookingById(int bookingId);
        public Task<bool> UpdateStatusBooking(int bookingId);
    }
}
