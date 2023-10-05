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
        public override async Task<IEnumerable<Booking>> GetAll()
        {
            return await _dbContext.Set<Booking>().Include(x=> x.Service)
                    .Include(x=> x.Store).Include(x=>x.BookingCategories).
                    ThenInclude(x=> x.Category).ToListAsync();
        }
    }
}
