using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class CategoryStoreEntity
	{
		public int CategoryStoreId { get; set; } // Primary Key
		// Foreign Key
		public int CategoryId { get; set; } // Table CategoryEntity
		public int StoreId { get; set; } // Table StoreEntity
		// Relationship
		public virtual StoreEntity? Store { get; set; }
		public virtual CategoryEntity? Category { get; set; }
	}
}
