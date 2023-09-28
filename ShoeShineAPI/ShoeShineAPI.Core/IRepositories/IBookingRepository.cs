﻿using ShoeShineAPI.Core.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.IRepositories
{
    public interface IBookingRepository:IGenericRepository<Booking>
    {
        public Task<int> GetBookingJustCreate();
    }
}
