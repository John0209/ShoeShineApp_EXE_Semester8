using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoeShineAPI.Infracstructure.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Infracstructure.Service_Extension
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddDIServices(this IServiceCollection services,
	   IConfiguration configuration)
		{
			services.AddDbContext<DbContextClass>(option =>
			{
				object value = option.UseSqlServer(configuration.GetConnectionString("ShoeShine"));
			});

			return services;
		}
		}
}
