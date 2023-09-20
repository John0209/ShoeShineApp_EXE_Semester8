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
	public class CommentStoreRepository : GenericRepository<Core.Model.CommentStoreEntity>, ICommentStoreRepository
	{
		public CommentStoreRepository(DbContextClass context) : base(context)
		{
		}
		public override async Task<IEnumerable<Core.Model.CommentStoreEntity>> GetAll()
		{
			return await _dbContext.Set<CommentStoreEntity>()
				.Include(s => s.ImageComments)
				.Include(s => s.RatingComment)
				.Include(s => s.User)
				.Include(s => s.Store)
				.ToListAsync();
		}
		public async Task<IEnumerable<Core.Model.CommentStoreEntity>> GetCommentByStoreId(int StoreId)
		{
			return await _dbContext.Set<CommentStoreEntity>()
				.Where(x => x.StoreId == StoreId)
				.Include(s => s.ImageComments)
				.Include(s => s.RatingComment)
				.Include(s => s.User)
				.Include(s => s.Store)
				.ToListAsync();
		}
	}
}
