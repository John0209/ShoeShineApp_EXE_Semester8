using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Comment
	{
		public int CommentId { get; set; }// Primary Key
		public string Content { get; set; } = string.Empty;
		// Foreign Key
		public Guid UserId { get; set; } // Table User
		public int ProductId { get; set; } // Table Product
		public int StoreId { get; set; } // Table Store
		// Relationship
		public ICollection<ImageComment>? ImageComments { get; set; }
		public User? User { get; set; }
		public Store? Store { get; set; }
		public Product? Product { get; set; }
	}
}
