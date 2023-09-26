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
		public ICollection<Product>? Products { get; set; }
		public ICollection<CategoryStore>? CategoryStores { get; set; }
	}
}
