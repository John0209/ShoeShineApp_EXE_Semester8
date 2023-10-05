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
		ICommentStoreRepository CommentRepository { get; }
		IImageStoreRepository ImageStoreRepository { get; }
		IProductRepository ProductRepository { get; }
		IRoleRepository RoleRepository { get; }
		IStoreRepository StoreRepository { get; }
		IUserRepository UserRepository { get; }
		IServiceRepository ServiceRepository { get; }
		IServiceStoreRepository ServiceStoreRepository { get; }
		IImageCommentRepository ImageCommentRepository { get; }
		ICategoryStoreRepository CategoryStoreRepository { get; }
		IRatingRepository RatingRepository { get; }
		IBookingRepository BookingRepository { get; }
		IOrderRepository OrderRepository { get; }
		IOrderDetailRepository OrderDetailRepository { get; }
		IPaymentMethodRepository PaymentMethodRepository { get; }
		ITransactionRepository TransactionRepository { get; }
		int Save();

    }
}
