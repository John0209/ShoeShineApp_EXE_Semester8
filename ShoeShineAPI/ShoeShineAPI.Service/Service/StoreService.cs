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
	public class StoreService : CommonAbstract<Store>, IStoreService
	{
		IUnitRepository _unit;

		public StoreService(IUnitRepository unit)
		{
			_unit = unit;
		}

		protected override async Task<IEnumerable<Core.Model.Store>> GetAllData()
		{
			return await _unit.StoreRepository.GetAll();
		}
	}
}
