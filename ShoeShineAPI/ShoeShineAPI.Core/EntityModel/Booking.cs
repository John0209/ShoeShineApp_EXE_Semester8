using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.EntityModel
{
    public class Booking
    {
        public int BookingId { get; set; }
        // Foreign Key
        public int ServiceId { get; set; }
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
        public int IsBookingStatus { get; set; }
        // Relationship
        public Service? Service { get; set; }
        public Store? Store { get; set; }
        public Category? Category { get; set; }
        public OrderDetail? OrderDetail { get; set; }
    }
}
