﻿using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
	public class CategoryStoreService : CommonAbstract<CategoryStore>, ICategoryStoreService
	{
		IUnitRepository _unit;

		public CategoryStoreService(IUnitRepository unit)
		{
			_unit = unit;
		}

		protected override async Task<IEnumerable<CategoryStore>> GetAllData()
		{
			return await _unit.CategoryStoreRepository.GetAll();
		}
	}
}