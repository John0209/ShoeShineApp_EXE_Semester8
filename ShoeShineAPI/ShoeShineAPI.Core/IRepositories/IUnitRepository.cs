using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IUnitRepository : IDisposable
	{
		ICategoryRepository CategoryRepository { get; }
		ICommentRepository CommentRepository { get; }
		IImageRepository ImageRepository { get; }
		IProductRepository ProductRepository { get; }
		IRoleRepository RoleRepository { get; }
		IStoreRepository StoreRepository { get; }
		IUserRepository UserRepository { get; }
		int Save();
	}
}
