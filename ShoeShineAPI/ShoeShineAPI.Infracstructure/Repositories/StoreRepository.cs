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
	public class StoreRepository : GenericRepository<Store>, IStoreRepository
	{
		public StoreRepository(DbContextClass context) : base(context)
		{
		}

        public override async Task<IEnumerable<Store>> GetAll()
        {
            return await _dbContext.Set<Store>()
                .Include(s => s.Images)
                .Include(s => s.Ratings)
                .ToListAsync();
        }

        public async Task<IEnumerable<Store>> GetStoresByName(string storeName)
        {
            return await _dbContext.Set<Store>()
                .Include(s => s.Images)
                .Include(s => s.Ratings)
                .Where(s => s.StoreName.Contains(storeName))
                .ToListAsync();
        }

        public override void Update(Store entity)
        {
            var existingStore = _dbContext.Set<Store>().Find(entity.StoreId);
            if (existingStore != null)
            {
                existingStore.StoreName = entity.StoreName;
                existingStore.StoreAddress = entity.StoreAddress;
                existingStore.StoreDescription = entity.StoreDescription;
                existingStore.StorePhone = entity.StorePhone;
                existingStore.StoreEmal = entity.StoreEmal;
            }
        }
        public override Task<Store?> GetById(int id)
        {
            return  _dbContext.Set<Store>().Where(x=> x.StoreId==id)
                .Include(s => s.Images)
                .Include(s => s.Ratings)
                .FirstOrDefaultAsync();
        }
    }
}
