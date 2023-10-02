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
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbContextClass context) : base(context)
        {
        }
        public override async Task<IEnumerable<OrderDetail>> GetAll()
        {
            return await _dbContext.Set<OrderDetail>()
                .Include(x=> x.Booking/*.Service*/)
                /*.Include(x=> x.Booking.Category)
                .Include(x => x.Booking.Store)*/.ToListAsync();
        }
    }
}
