using ShoeShineAPI.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class CategoryEntity
	{
		public int CategoryId { get; set; }// Primary Key
		public string CategoryName { get; set; } = string.Empty;
		public bool IsCategoryStatus { get; set; }
		// Relationship
		public ICollection<ProductEntity>? Products { get; set; }
		public ICollection<CategoryStoreEntity>? CategoryStores { get; set; }
	}
}
