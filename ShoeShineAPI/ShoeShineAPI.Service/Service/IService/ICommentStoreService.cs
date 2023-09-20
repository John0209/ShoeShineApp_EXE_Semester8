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
		public Task<IEnumerable<CommentStoreEntity>> GetCommentByStoreId(int storeId);
		public Task<IEnumerable<CommentStoreEntity>> GetCommentAsync();
	}
}
