using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class ImageComment
	{
		public Guid ImageCommentId { get; set; }// Primary Key
		public string ImageCommentURL { get; set; } = string.Empty;
		// Foreign Key
		public Guid CommentStoreId { get; set; } // Table Comment
		// Relationship
		public virtual CommentStore? CommentStore { get; set; }
	}
}
