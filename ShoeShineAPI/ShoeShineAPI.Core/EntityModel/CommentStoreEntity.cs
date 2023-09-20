using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class CommentStoreEntity
	{
		public int CommentStoreId { get; set; }// Primary Key
		public string Content { get; set; } = string.Empty;
		// Foreign Key
		public Guid UserId { get; set; } // Table UserEntity
		//public int ProductId { get; set; } // Table ProductEntity
		public int StoreId { get; set; } // Table StoreEntity
		public int RatingCommentId { get; set; }// Table Rating
		// Relationship
		public ICollection<ImageCommentEntity>? ImageComments { get; set; }
		public virtual UserEntity? User { get; set; }
		public virtual StoreEntity? Store { get; set; }
		//public virtual ProductEntity? ProductEntity { get; set; }
		public virtual RatingCommentEntity? RatingComment { get; set; }
	}
}
