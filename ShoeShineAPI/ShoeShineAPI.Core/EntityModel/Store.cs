using ShoeShineAPI.Core.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Store
	{
		public int StoreId { get; set; }// Primary Key
		public string StoreName { get; set; } =string.Empty;
		public string StoreAddress { get; set; } =string.Empty;
		public string StoreDescription { get; set; } = string.Empty;
		public string StorePhone { get; set; } = string.Empty;
        public string StoreEmal { get; set; } = string.Empty;
        public bool IsStoreStatus { get; set; } = true;
        //Foreign Key
        public int RatingId { get; set; }
        // Relationship
        public ICollection<CommentStore>? Comments { get; set; }
		public ICollection<ImageStore>? Images { get; set; }
		public ICollection<ServiceStore>? ServiceStores { get; set; }
		public ICollection<CategoryStore>? CategoryStores { get; set; }
		public virtual Rating? Ratings { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
