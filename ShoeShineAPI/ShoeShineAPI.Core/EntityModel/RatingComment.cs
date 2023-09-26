using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class RatingComment
	{
		public int RatingCommentId { get; set; } // Primary Key
		public int RatingCommentScale { get; set; } 
		// Relationship
		public virtual CommentStore? Comment { get; set; }
	}
}
