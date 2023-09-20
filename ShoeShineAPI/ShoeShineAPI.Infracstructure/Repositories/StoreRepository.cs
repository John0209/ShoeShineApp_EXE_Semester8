using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
	public class StoreRepository : GenericRepository<StoreEntity>, IStoreRepository
	{
		public StoreRepository(DbContextClass context) : base(context)
		{
		}

        public override async Task<IEnumerable<StoreEntity>> GetAll()
        {
            return await _dbContext.Set<StoreEntity>()
                .Include(s => s.Images)
                .Include(s => s.RatingStores)
                .ToListAsync();
        }
    }
}
