using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class BookingRequest
    {
        public int BookingId { get; set; }
        // Foreign Key
        public int ServiceId { get; set; }
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
    }
}
