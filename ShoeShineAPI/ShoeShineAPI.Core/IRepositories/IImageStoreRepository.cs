﻿using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
	public interface IImageStoreRepository : IGenericRepository<ImageStore>
	{
        public Task<List<ImageStore>> GetListImageByStoreId(int id);

    }
}
