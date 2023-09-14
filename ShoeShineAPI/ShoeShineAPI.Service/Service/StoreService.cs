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

		public async Task<IEnumerable<Store>> GetStoresAsync()
		{
			var stores= await GetAllDataAsync();
			return stores;
		}

		protected override async Task<IEnumerable<Core.Model.Store>> GetAllDataAsync()
		{
			return await _unit.StoreRepository.GetAll();
		}
	}
}
