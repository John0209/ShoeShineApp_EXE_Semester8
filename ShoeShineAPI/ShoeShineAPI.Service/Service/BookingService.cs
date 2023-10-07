using ShoeShineAPI.Core.EntityModel;
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

        public async Task<bool> CreateBooking(Booking booking, int[]? categoryIdArray)
        {
            var checkStatus = await GetBookingJustCreate();
            // xem thử có booking nào ở status create không,nếu có thì phải tạo orderdetail,không thể tạo thêm booking
            if (checkStatus == 0)
            {
                await _unit.BookingRepository.Add(booking);
                var result = _unit.Save();
                if (result > 0)
                {
                    foreach(var x in categoryIdArray)
                    {
                        var bookingcategory = new BookingCategory();
                        bookingcategory.CategoryId = x;
                        bookingcategory.BookingId = booking.BookingId;
                        await _unit.BookingCategoryRepository.Add(bookingcategory);
                        _unit.Save();
                    }
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Booking>> GetBookingAsync()
        {
            return await GetAllDataAsync();
        }

        public async Task<Booking?> GetBookingById(int bookingId)
        {
            return await _unit.BookingRepository.GetById(bookingId);
        }

        public async Task<int> GetBookingJustCreate()
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

        public async Task RemoveAllBookings()
        {
            var bookings = await _unit.BookingRepository.GetAll();
            if(bookings != null && bookings.Any())
            {
                var bookingCategories = await _unit.BookingCategoryRepository.GetAll();
                if (bookingCategories != null && bookingCategories.Any())
                {
                    _unit.BookingCategoryRepository.RemoveRange(bookingCategories);
                }

                _unit.BookingRepository.RemoveRange(bookings);
                _unit.Save();
            }
        }
    }
}
