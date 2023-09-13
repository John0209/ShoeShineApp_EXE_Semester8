using ShoeShineAPI.Core.IRepositories;
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
	public class CategoryService : CommonAbstract<Category>, ICategoryService
	{
		IUnitRepository _unit;

		public CategoryService(IUnitRepository unit)
		{
			_unit = unit;
		}

		protected override async Task<IEnumerable<Category>> GetAllData()
		{
			return await _unit.CategoryRepository.GetAll();
		}
	}
}
