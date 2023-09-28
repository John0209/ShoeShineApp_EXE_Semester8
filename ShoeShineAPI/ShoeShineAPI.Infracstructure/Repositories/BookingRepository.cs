using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.EntityModel;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DbContextClass context) : base(context)
        {
        }

        public Task<int> GetBookingJustCreate()
        {
            return _dbContext.Set<Booking>().Where(x => x.IsBookingStatus == 1)
                .Select(x => x.BookingId).FirstOrDefaultAsync();
        }
    }
}
