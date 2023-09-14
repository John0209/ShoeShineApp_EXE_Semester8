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
		public bool IsStoreStatus { get; set; } = true;
		//Foreign Key

		// Relationship
		public ICollection<Comment>? Comments { get; set; }
		public ICollection<Image>? Images { get; set; }
		public ICollection<ServiceStore>? ServiceStores { get; set; }
		public ICollection<CategoryStore>? CategoryStores { get; set; }
	}
}
