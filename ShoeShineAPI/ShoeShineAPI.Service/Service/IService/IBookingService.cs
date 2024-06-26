﻿using ShoeShineAPI.Core.EntityModel;
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
        public Task<bool> CreateBooking(Booking booking, int[]? categoryIdArray);
        public Task<int> GetBookingJustCreate();
        public Task<Booking?> GetBookingById(int bookingId);
        public Task<bool> UpdateStatusBooking(int bookingId);
        public Task RemoveAllBookings();
    }
}
