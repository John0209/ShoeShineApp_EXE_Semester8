using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.ResponeModel
{
    public class BookingRespone
    {
        public int BookingId { get; set; }
        //FK
        public int ServiceId { get; set; }
        public int StoreId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
        public List<string> CategoryName { get; set; } = new List<string>();
        public int IsBookingStatus { get; set; }
    }
}
