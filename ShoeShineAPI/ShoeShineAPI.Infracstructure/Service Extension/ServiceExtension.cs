using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using ShoeShineAPI.Infracstructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Service_Extension;

public static class ServiceExtension
{
	public static IServiceCollection AddDIServices(this IServiceCollection services,
   IConfiguration configuration)
	{
		services.AddDbContext<DbContextClass>(option =>
		{
			object value = option.UseSqlServer(configuration.GetConnectionString("ShoeShine"));
		});
		services.AddScoped<IUnitRepository, UnitRepository>();
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<ICommentStoreRepository, CommentStoreRepository>();
		services.AddScoped<IImageStoreRepository, ImageStoreRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IRoleRepository , RoleRepository>();
		services.AddScoped<IStoreRepository, StoreRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IServiceRepository, ServiceRepository>();
		services.AddScoped<IServiceStoreRepository, ServiceStoreRepository>();
		services.AddScoped<ICategoryStoreRepository, CategoryStoreRepository>();
		services.AddScoped<IImageCommentRepository, ImageCommentRepository>();
		services.AddScoped<IRatingCommentRepository, RatingCommentRepository>();
		services.AddScoped<IRatingStoreRepository, RatingStoreRepository>();
		return services;
	}
}
