﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
    public interface IImageStoreService
    {
        public Task<bool> CraeteImageStore(int storeId, string url);
    }
}
