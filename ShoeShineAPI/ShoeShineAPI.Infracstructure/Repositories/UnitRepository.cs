﻿using ShoeShineAPI.Core.IRepositories;
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

		public ICommentRepository CommentRepository { get; }

		public IImageRepository ImageRepository { get; }

		public IProductRepository ProductRepository { get; }

		public IRoleRepository RoleRepository { get; }

		public IStoreRepository StoreRepository { get; }

		public IUserRepository UserRepository { get; }

		public UnitRepository(DbContextClass dbContextClass, ICategoryRepository categoryRepository,
			ICommentRepository commentRepository, IImageRepository imageRepository, IProductRepository productRepository, 
			IRoleRepository roleRepository, IStoreRepository storeRepository, IUserRepository userRepository)
		{
			_dbContextClass = dbContextClass;
			CategoryRepository = categoryRepository;
			CommentRepository = commentRepository;
			ImageRepository = imageRepository;
			ProductRepository = productRepository;
			RoleRepository = roleRepository;
			StoreRepository = storeRepository;
			UserRepository = userRepository;
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