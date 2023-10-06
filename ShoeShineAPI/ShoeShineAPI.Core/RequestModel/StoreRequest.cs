using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class StoreRequest
    {
        public int StoreId { get; set; }// Primary Key
        public string StoreName { get; set; } = string.Empty;
        public string StoreAddress { get; set; } = string.Empty;
        public string StoreDescription { get; set; } = string.Empty;
        public string StorePhone { get; set; } = string.Empty;
        public string StoreEmal { get; set; } = string.Empty;
        public bool IsStoreStatus { get; set; } = true;
    }
}
