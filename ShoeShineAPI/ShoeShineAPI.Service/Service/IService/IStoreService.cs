using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface IStoreService
	{
		public Task<IEnumerable<StoreEntity>> GetStoresAsync();
	}
}
