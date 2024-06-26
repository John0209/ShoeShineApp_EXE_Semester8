﻿using Microsoft.EntityFrameworkCore;
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
	public class CommentStoreRepository : GenericRepository<Core.Model.CommentStore>, ICommentStoreRepository
	{
		public CommentStoreRepository(DbContextClass context) : base(context)
		{
		}
		public override async Task<IEnumerable<Core.Model.CommentStore>> GetAll()
		{
			return await _dbContext.Set<CommentStore>()
				.Include(s => s.ImageComments)
				.Include(s => s.Ratings)
				.Include(s => s.User)
				.Include(s => s.Store)
				.ToListAsync();
		}
		public async Task<IEnumerable<Core.Model.CommentStore>> GetCommentByStoreId(int StoreId)
		{
			return await _dbContext.Set<CommentStore>()
				.Where(x => x.StoreId == StoreId)
				.Include(s => s.ImageComments)
				.Include(s => s.Ratings)
				.Include(s => s.User)
				.Include(s => s.Store)
				.ToListAsync();
		}

        public override async Task<CommentStore?> GetById(int id)
        {
            return await _dbContext.Set<CommentStore>()
                .Where(x => x.CommentStoreId == id)
                .Include(s => s.ImageComments)
                .Include(s => s.Ratings)
                .Include(s => s.User)
                .Include(s => s.Store)
                .FirstOrDefaultAsync();
        }

        public override void Update(CommentStore entity)
        {
			var existingComment = _dbContext.Set<CommentStore>().Find(entity.CommentStoreId);
			if (existingComment != null)
			{
				existingComment.Content = entity.Content;
				existingComment.UserId = entity.UserId;
				existingComment.StoreId = entity.StoreId;
				existingComment.RatingId = entity.RatingId;
			}
        }
    }
}
