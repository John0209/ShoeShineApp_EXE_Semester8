using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.EntityModel
{
    public class BookingCategory
    {
        public int BookingCategoryId { get; set; }
        //FK
        public int CategoryId { get; set; }
        public int BookingId { get; set; }
        //Relationship
        public virtual Booking? Booking { get; set; }
        public virtual Category? Category { get; set; }
    }
}
