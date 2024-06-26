﻿using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IServiceStoreRepository:IGenericRepository<ServiceStore>
	{
        public List<int> GetServiceStoreId(int storeId);
        public Task<ServiceStore?> CheckServiceStoreExist(int storeId, int serviceId);

    }
}
