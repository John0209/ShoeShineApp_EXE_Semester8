using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface ICommentStoreService
	{
		public Task<IEnumerable<CommentStore>> GetCommentByStoreId(int storeId);
		public Task<IEnumerable<CommentStore>> GetCommentAsync();
		public Task<CommentStore> GetCommentById(Guid id);
		public Task CreateCommentAsync(CommentStore entity);
		public Task UpdateCommentAsync(CommentStore entity);
		public Task CreateImagesCommentAsync(IEnumerable<ImageComment> entities);
        public Task DeleteImagesCommentByCommentStoreIdAsync(Guid commentStoreId);
    }
}
