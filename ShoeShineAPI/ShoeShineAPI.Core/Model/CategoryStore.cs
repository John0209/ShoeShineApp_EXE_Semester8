using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class CategoryStore
	{
		public int CategoryStoreId { get; set; } // Primary Key
		// Foreign Key
		public int CategoryId { get; set; } // Table Category
		public int StoreId { get; set; } // Table Store
		// Relationship
		public Store? Store { get; set; }
		public Category? Category { get; set; }
	}
}
