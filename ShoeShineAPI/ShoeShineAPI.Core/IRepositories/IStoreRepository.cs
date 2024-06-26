﻿using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IStoreRepository : IGenericRepository<Store>
	{
		Task<IEnumerable<Store>> GetStoresByName(string storeName);
	}
}
