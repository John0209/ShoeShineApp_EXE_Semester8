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
    public class BookingCategoryRepository : GenericRepository<BookingCategory>, IBookingCategoryRepository
    {
        public BookingCategoryRepository(DbContextClass context) : base(context)
        {
        }
    }
}
