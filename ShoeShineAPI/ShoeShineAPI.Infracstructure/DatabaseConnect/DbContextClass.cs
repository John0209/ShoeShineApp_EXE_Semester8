using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.Model;

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
	public DbSet<CategoryEntity> Category { get; set; }
	public DbSet<CategoryStoreEntity> CategoryStore { get; set; }
	public DbSet<ProductEntity> Product { get; set; }
	public DbSet<CommentStoreEntity> CommentStore { get; set; }
	public DbSet<UserEntity> User { get; set; }
	public DbSet<StoreEntity> Store { get; set; }
	public DbSet<RoleEntity> Role { get; set; }
	public DbSet<ImageStoreEntity> ImageStore { get; set; }
	public DbSet<ImageCommentEntity> ImageComment { get; set; }
	public DbSet<ServiceEntity> Service { get; set; }
	public DbSet<ServiceStoreEntity> ServiceStore { get; set; }
	public DbSet<RatingCommentEntity> RatingComment { get; set; }
	public DbSet<RatingStoresEntity> RatingStores { get; set; }
	#endregion
	protected override void OnModelCreating(ModelBuilder model)
	{
		model.Entity<RoleEntity>(e =>
		{
			e.ToTable(nameof(Role));
			e.HasKey(x => x.RoleId);
			e.Property(x => x.RoleName).HasColumnType("varchar(10)").IsRequired();
		}); 
		model.Entity<UserEntity>(e =>
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
		model.Entity<ImageCommentEntity>(e =>
		{
			e.ToTable(nameof (ImageComment));
			e.HasKey(x => x.ImageCommentId);
			e.Property(x => x.ImageCommentURL).HasColumnType("varchar(100)").IsRequired();
			e.HasOne(x => x.CommentStore).WithMany(x => x.ImageComments).HasForeignKey(x => x.CommentStoreId);
		});
		model.Entity<CommentStoreEntity>(e=>
		{
			e.ToTable(nameof (CommentStore));
			e.HasKey(x => x.CommentStoreId);
			e.HasOne(x=>x.User).WithMany(x=> x.Comments).HasForeignKey(x=>x.UserId);
			e.HasOne(x => x.Store).WithMany(x => x.Comments).HasForeignKey(x => x.StoreId);
			e.HasOne(x => x.RatingComment).WithOne(x => x.Comment).HasForeignKey<CommentStoreEntity>(x => x.RatingCommentId)
			.HasConstraintName("FK_Rating_Comment"); ;
			e.Property(x => x.Content).HasColumnType("nvarchar(200)").IsRequired();
		});
		model.Entity<ImageStoreEntity>(e =>
		{
			e.ToTable (nameof (ImageStore));
			e.HasKey(x=> x.ImageStoreId);
			e.HasOne(x => x.Store).WithMany(x => x.Images).HasForeignKey(x => x.StoreId);
			e.Property(x => x.ImageURL).HasColumnType("nvarchar(150)").IsRequired();
		});
		model.Entity<StoreEntity>(e =>
		{
			e.ToTable(nameof(Store));
			e.HasKey(x => x.StoreId);
			e.Property(x => x.StoreName).HasColumnType("nvarchar(50)").IsRequired();
			e.Property(x => x.StoreAddress).HasColumnType("nvarchar(50)").IsRequired();
		});
		model.Entity<ProductEntity>(e =>
		{
			e.ToTable(nameof(Product));
			e.HasKey(x => x.ProductId);
			e.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
			e.Property(x => x.ProductName).HasColumnType("nvarchar(50)").IsRequired();
			e.Property(x => x.ProductDescription).HasColumnType("nvarchar(150)");
		});
		model.Entity<CategoryEntity>(e =>
		{
			e.ToTable(nameof(Category));
			e.HasKey(x => x.CategoryId);
			e.Property(x => x.CategoryName).HasColumnType("varchar(50)").IsRequired();
		});
		model.Entity<CategoryStoreEntity>(e =>
		{
			e.ToTable(nameof(CategoryStore));
			e.HasKey(x => x.CategoryStoreId);
			e.HasOne(x => x.Category).WithMany(x => x.CategoryStores).HasForeignKey(x => x.CategoryId);
			e.HasOne(x => x.Store).WithMany(x => x.CategoryStores).HasForeignKey(x => x.StoreId);
		});
		model.Entity<ServiceEntity>(e =>
		{
			e.ToTable(nameof(Service));
			e.HasKey(x => x.ServiceId);
			e.Property(x => x.ServiceName).HasColumnType("varchar(50)").IsRequired();
		});
		model.Entity<ServiceStoreEntity>(e =>
		{
			e.ToTable(nameof(ServiceStore));
			e.HasKey(x => x.ServiceStoreId);
			e.HasOne(x => x.Service).WithMany(x => x.ServiceStores).HasForeignKey(x => x.ServiceId);
			e.HasOne(x => x.Store).WithMany(x => x.ServiceStores).HasForeignKey(x => x.StoreId);
		});
		model.Entity<RatingStoresEntity>(e =>
		{
			e.ToTable(nameof(RatingStores));
			e.HasKey(x => x.RatingStoresId);
			e.HasOne(x => x.Store).WithOne(x => x.RatingStores).HasForeignKey<RatingStoresEntity>(x => x.StoreId)
			.HasConstraintName("FK_Rating_Store");
		});
		model.Entity<RatingCommentEntity>(e =>
		{
			e.ToTable(nameof(RatingComment));
			e.HasKey(x => x.RatingCommentId);
		});
	}

	}
