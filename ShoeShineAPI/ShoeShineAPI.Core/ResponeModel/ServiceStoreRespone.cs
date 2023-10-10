using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class ServiceStoreRespone
    {
        public int ServiceId { get; set; } // Table Service
        public string ServiceName { get; set; }=string.Empty;
        public int StoreId { get; set; } // Table StoreEntity
        public string StoreName { get; set; } = string.Empty;
        public float ServicePrice { get; set; }
        public bool IsServiceStoreStatus { get; set; }
    }
}
