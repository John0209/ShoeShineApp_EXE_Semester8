using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class OrderDetailRequest
    {
        public int OrderDetailId { get; set; }
        //FK
        public int OrderId { get; set; }
        public int BookingId { get; set; }
        public int QuantityItem { get; set; }
        public float ShipFee { get; set; }
    }
}
