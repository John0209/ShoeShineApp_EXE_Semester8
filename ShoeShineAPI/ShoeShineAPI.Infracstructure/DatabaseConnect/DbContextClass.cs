using Microsoft.EntityFrameworkCore;
using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	public DbSet<Category> Categorie { get; set; }
	public DbSet<Product> Product { get; set; }
	public DbSet<Comment> Comment { get; set; }
	public DbSet<User> User { get; set; }
	public DbSet<Store> Store { get; set; }
	public DbSet<Role> Role { get; set; }
	public DbSet<Image> Image { get; set; }
	#endregion
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

	}
	}
