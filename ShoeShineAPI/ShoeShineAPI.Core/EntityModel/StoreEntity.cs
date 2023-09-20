using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class StoreEntity
	{
		public int StoreId { get; set; }// Primary Key
		public string StoreName { get; set; } =string.Empty;
		public string StoreAddress { get; set; } =string.Empty;
		public string StoreDescription { get; set; } = string.Empty;
		public bool IsStoreStatus { get; set; } = true;
		//Foreign Key
		
		// Relationship
		public ICollection<CommentStoreEntity>? Comments { get; set; }
		public ICollection<ImageStoreEntity>? Images { get; set; }
		public ICollection<ServiceStoreEntity>? ServiceStores { get; set; }
		public ICollection<CategoryStoreEntity>? CategoryStores { get; set; }
		public virtual RatingStoresEntity? RatingStores { get; set; }
	}
}
