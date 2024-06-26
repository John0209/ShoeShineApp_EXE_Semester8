﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class CategoryStoreRespone
    {
        public int CategoryId { get; set; } // Table Service
        public string CategoryName { get; set; } = string.Empty;
        public int StoreId { get; set; } // Table StoreEntity
        public string StoreName { get; set; } = string.Empty;
        public bool IsCategoryStoreStatus { get; set; }
    }
}
