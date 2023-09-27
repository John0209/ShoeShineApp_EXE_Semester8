using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.EntityModel;

namespace ShoeShineAPI.Infracstructure.DatabaseConnect;

public class DbContextClass: DbContext
{
	public DbContextClass()
	{

	}
	public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
	{

	}
	#region DbSet
	public DbSet<Category> Category { get; set; }
	public DbSet<CategoryStore> CategoryStore { get; set; }
	public DbSet<Product> Product { get; set; }
	public DbSet<CommentStore> CommentStore { get; set; }
	public DbSet<User> User { get; set; }
	public DbSet<Store> Store { get; set; }
	public DbSet<Role> Role { get; set; }
	public DbSet<ImageStore> ImageStore { get; set; }
	public DbSet<ImageComment> ImageComment { get; set; }
	public DbSet<Service> Service { get; set; }
	public DbSet<ServiceStore> ServiceStore { get; set; }
	public DbSet<RatingComment> RatingComment { get; set; }
	public DbSet<RatingStores> RatingStores { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<PaymentMethod> PaymentMethod { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<Booking> Booking { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder model)
	{
		model.Entity<Role>(e =>
		{
			e.ToTable(nameof(Role));
			e.HasKey(x => x.RoleId);
			e.Property(x => x.RoleName).HasColumnType("varchar(10)").IsRequired();
		}); 
		model.Entity<User>(e =>
		{
			e.ToTable(nameof (User));
			e.HasKey(x => x.UserId);
			e.HasOne(x=> x.Role).WithMany(x=> x.Users).HasForeignKey(x=>x.RoleId);
			e.Property(x => x.UserName).HasColumnType("nvarchar(50)").IsRequired();
			e.Property(x => x.UserPhone).HasColumnType("varchar(15)").IsRequired();
			e.Property(x => x.UserEmail).HasColumnType("varchar(30)").IsRequired();
			e.Property(x => x.UserAddress).HasColumnType("nvarchar(50)").IsRequired();
			e.Property(x => x.UserAccount).HasColumnType("varchar(20)").IsRequired();
			e.Property(x => x.UserPassword).HasColumnType("varchar(20)").IsRequired();
		});
		model.Entity<ImageComment>(e =>
		{
			e.ToTable(nameof (ImageComment));
			e.HasKey(x => x.ImageCommentId);
			e.Property(x => x.ImageCommentURL).HasColumnType("varchar(100)").IsRequired();
			e.HasOne(x => x.CommentStore).WithMany(x => x.ImageComments).HasForeignKey(x => x.CommentStoreId);
		});
		model.Entity<CommentStore>(e=>
		{
			e.ToTable(nameof (CommentStore));
			e.HasKey(x => x.CommentStoreId);
			e.HasOne(x=>x.User).WithMany(x=> x.Comments).HasForeignKey(x=>x.UserId);
			e.HasOne(x => x.Store).WithMany(x => x.Comments).HasForeignKey(x => x.StoreId);
			e.HasOne(x => x.RatingComment).WithOne(x => x.Comment).HasForeignKey<CommentStore>(x => x.RatingCommentId)
			.HasConstraintName("FK_Rating_Comment"); ;
			e.Property(x => x.Content).HasColumnType("nvarchar(200)").IsRequired();
		});
		model.Entity<ImageStore>(e =>
		{
			e.ToTable (nameof (ImageStore));
			e.HasKey(x=> x.ImageStoreId);
			e.HasOne(x => x.Store).WithMany(x => x.Images).HasForeignKey(x => x.StoreId);
			e.Property(x => x.ImageURL).HasColumnType("nvarchar(150)").IsRequired();
		});
		model.Entity<Store>(e =>
		{
			e.ToTable(nameof(Store));
			e.HasKey(x => x.StoreId);
			e.Property(x => x.StoreName).HasColumnType("nvarchar(50)").IsRequired();
			e.Property(x => x.StoreAddress).HasColumnType("nvarchar(50)").IsRequired();
		});
		model.Entity<Product>(e =>
		{
			e.ToTable(nameof(Product));
			e.HasKey(x => x.ProductId);
			e.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
			e.Property(x => x.ProductName).HasColumnType("nvarchar(50)").IsRequired();
			e.Property(x => x.ProductDescription).HasColumnType("nvarchar(150)");
		});
		model.Entity<Category>(e =>
		{
			e.ToTable(nameof(Category));
			e.HasKey(x => x.CategoryId);
			e.Property(x => x.CategoryName).HasColumnType("varchar(50)").IsRequired();
		});
		model.Entity<CategoryStore>(e =>
		{
			e.ToTable(nameof(CategoryStore));
			e.HasKey(x => x.CategoryStoreId);
			e.HasOne(x => x.Category).WithMany(x => x.CategoryStores).HasForeignKey(x => x.CategoryId);
			e.HasOne(x => x.Store).WithMany(x => x.CategoryStores).HasForeignKey(x => x.StoreId);
		});
		model.Entity<Service>(e =>
		{
			e.ToTable(nameof(Service));
			e.HasKey(x => x.ServiceId);
			e.Property(x => x.ServiceName).HasColumnType("varchar(50)").IsRequired();
		});
		model.Entity<ServiceStore>(e =>
		{
			e.ToTable(nameof(ServiceStore));
			e.HasKey(x => x.ServiceStoreId);
			e.HasOne(x => x.Service).WithMany(x => x.ServiceStores).HasForeignKey(x => x.ServiceId);
			e.HasOne(x => x.Store).WithMany(x => x.ServiceStores).HasForeignKey(x => x.StoreId);
		});
		model.Entity<RatingStores>(e =>
		{
			e.ToTable(nameof(RatingStores));
			e.HasKey(x => x.RatingStoresId);
			e.HasOne(x => x.Store).WithOne(x => x.RatingStores).HasForeignKey<RatingStores>(x => x.StoreId)
			.HasConstraintName("FK_Rating_Store");
		});
		model.Entity<RatingComment>(e =>
		{
			e.ToTable(nameof(RatingComment));
			e.HasKey(x => x.RatingCommentId);
		});
		//Payment - Order
        model.Entity<PaymentMethod>(e =>
        {
            e.ToTable(nameof(PaymentMethod));
            e.HasKey(x => x.PaymentMethodId);
        });
        model.Entity<Payment>(e =>
        {
            e.ToTable(nameof(Payment));
            e.HasKey(x => x.PaymentId);
			e.HasOne(x => x.PaymentMethod).WithMany(x => x.Payments).HasForeignKey(x => x.PaymentMethodId);
        });
        model.Entity<Order>(e =>
        {
            e.ToTable(nameof(Order));
            e.HasKey(x => x.OrderId);
            e.HasOne(x => x.Payment).WithMany(x => x.Orders).HasForeignKey(x => x.PaymentId);
            e.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        });
        model.Entity<OrderDetail>(e =>
        {
            e.ToTable(nameof(OrderDetail));
            e.HasKey(x => x.OrderDetailId);
            e.HasOne(x => x.Order).WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.OrderId);
            e.HasOne(x => x.Booking).WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.BookingId);
        });
        model.Entity<Booking>(e =>
        {
            e.ToTable(nameof(Booking));
            e.HasKey(x => x.BookingId);
            e.HasOne(x => x.Service).WithMany(x => x.Bookings).HasForeignKey(x => x.ServiceId);
            e.HasOne(x => x.Store).WithMany(x => x.Bookings).HasForeignKey(x => x.StoreId);
            e.HasOne(x => x.Category).WithMany(x => x.Bookings).HasForeignKey(x => x.CategoryId);
        });


    }

	}
