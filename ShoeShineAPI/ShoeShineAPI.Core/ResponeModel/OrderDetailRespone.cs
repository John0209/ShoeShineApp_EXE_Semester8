using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class OrderDetailRespone
    {
        public int OrderDetailId { get; set; }
        //FK
        public string ServiceName { get; set; }=string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int QuantityItem { get; set; }
        public float ShipFee { get; set; }
    }
}
