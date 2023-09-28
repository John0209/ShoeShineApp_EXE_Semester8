using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class BookingRequest
    {
        [JsonIgnore]
        public int BookingId { get; set; } = 0;
        // Foreign Key
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public int IsBookingStatus { get; set; } = 1;
    }
}
