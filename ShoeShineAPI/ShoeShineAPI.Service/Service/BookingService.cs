﻿using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class BookingService : CommonAbstract<Booking>, IBookingService
    {
        IUnitRepository _unit;

        public BookingService(IUnitRepository unit)
        {
            _unit = unit;
        }

        public async Task<bool> CreateBooking(Booking booking)
        {
            var checkStatus = await GetBookingIdByStatus2();
            if (checkStatus == 0)
            {
                await _unit.BookingRepository.Add(booking);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<IEnumerable<Booking>> GetBookingAsync()
        {
            return await GetAllDataAsync();
        }

        public async Task<Booking> GetBookingById(int bookingId)
        {
            return await _unit.BookingRepository.GetById(bookingId);
        }

        public async Task<int> GetBookingIdByStatus2()
        {
            return await _unit.BookingRepository.GetBookingJustCreate();
        }

        public async Task<bool> UpdateStatusBooking(int bookingId)
        {
            var booking= await _unit.BookingRepository.GetById(bookingId);
            if(booking != null)
            {
                booking.IsBookingStatus = 2;
                _unit.BookingRepository.Update(booking);
                var result = _unit.Save();
                if(result > 0) return true;
            }
            return false;
        }

        protected override async Task<IEnumerable<Booking>> GetAllDataAsync()
        {
            return await _unit.BookingRepository.GetAll();
        }
    }
}