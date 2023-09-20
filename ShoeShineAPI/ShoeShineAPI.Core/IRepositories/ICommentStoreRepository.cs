using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{

	public interface ICommentStoreRepository : IGenericRepository<CommentStoreEntity>
	{
		public Task<IEnumerable<CommentStoreEntity>> GetCommentByStoreId(int StoreId);
	}
}
