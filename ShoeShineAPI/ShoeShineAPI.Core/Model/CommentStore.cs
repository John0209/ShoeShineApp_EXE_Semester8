using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class CommentStore
	{
		public int CommentStoreId { get; set; }// Primary Key
		public string Content { get; set; } = string.Empty;
		// Foreign Key
		public Guid UserId { get; set; } // Table User
		//public int ProductId { get; set; } // Table Product
		public int StoreId { get; set; } // Table Store
		public int RatingCommentId { get; set; }// Table Rating
		// Relationship
		public ICollection<ImageComment>? ImageComments { get; set; }
		public virtual User? User { get; set; }
		public virtual Store? Store { get; set; }
		//public virtual Product? Product { get; set; }
		public virtual RatingComment? RatingComment { get; set; }
	}
}
