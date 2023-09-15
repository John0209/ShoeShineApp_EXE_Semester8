using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Product
	{
		public int ProductId { get; set; }// Primary Key
		public string ProductName { get; set; } = string.Empty;
		public string ProductDescription { get; set; } =string.Empty;
		public int ProductQuantity { get; set; }
		public float ProductPrice { get; set; }
		public float ProductAmount { get; set; }
		public bool IsProductStatus { get; set; } = true;
		// Foreign Key
		public int CategoryId { get; set; } // Table Category
		//public int RatingId { get; set; }// Table Rating
		// Relationship
		public ICollection<Comment>? Comments { get; set; }
		public ICollection<Image>? Images { get; set; }
		public virtual Category? Category { get; set; }

	}
}
