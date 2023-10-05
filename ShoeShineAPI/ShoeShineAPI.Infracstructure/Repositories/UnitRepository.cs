using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Repositories
{
	public class UnitRepository : IUnitRepository
	{
		private readonly DbContextClass _dbContextClass;
		public ICategoryRepository CategoryRepository { get; }

		public ICommentStoreRepository CommentRepository { get; }

		public IImageStoreRepository ImageStoreRepository { get; }

		public IProductRepository ProductRepository { get; }

		public IRoleRepository RoleRepository { get; }

		public IStoreRepository StoreRepository { get; }

		public IUserRepository UserRepository { get; }

		public IServiceRepository ServiceRepository { get; }
		public IServiceStoreRepository ServiceStoreRepository { get; }
		public IImageCommentRepository ImageCommentRepository { get; }
		public ICategoryStoreRepository CategoryStoreRepository { get; }

		public IRatingRepository RatingRepository { get; }

        public IBookingRepository BookingRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }

        public IPaymentMethodRepository PaymentMethodRepository  { get; }

		public ITransactionRepository TransactionRepository { get; }

        public IBookingCategoryRepository BookingCategoryRepository { get; }

        public UnitRepository(DbContextClass dbContextClass, ICategoryRepository categoryRepository,
			ICommentStoreRepository commentRepository, IImageStoreRepository imageStoreRepository, 
			IProductRepository productRepository, IRoleRepository roleRepository, IStoreRepository storeRepository, 
			IUserRepository userRepository, IServiceRepository serviceRepository, IServiceStoreRepository serviceStoreRepository
			, IImageCommentRepository imageCommentRepository, ICategoryStoreRepository categoryStoreRepository, 
			IRatingRepository ratingRepository, IBookingRepository bookingRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IPaymentMethodRepository paymentMethodRepository, ITransactionRepository transactionRepository, IBookingCategoryRepository bookingCategoryRepository)
        {
            _dbContextClass = dbContextClass;
            CategoryRepository = categoryRepository;
            CommentRepository = commentRepository;
            ImageStoreRepository = imageStoreRepository;
            ProductRepository = productRepository;
            RoleRepository = roleRepository;
            StoreRepository = storeRepository;
            UserRepository = userRepository;
            ServiceRepository = serviceRepository;
            ServiceStoreRepository = serviceStoreRepository;
            ImageCommentRepository = imageCommentRepository;
            CategoryStoreRepository = categoryStoreRepository;
            RatingRepository = ratingRepository;
            BookingRepository = bookingRepository;
            OrderRepository = orderRepository;
            OrderDetailRepository = orderDetailRepository;
            PaymentMethodRepository = paymentMethodRepository;
            TransactionRepository = transactionRepository;
            BookingCategoryRepository = bookingCategoryRepository;
        }

        public int Save()
		{
			return _dbContextClass.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_dbContextClass.Dispose();
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
