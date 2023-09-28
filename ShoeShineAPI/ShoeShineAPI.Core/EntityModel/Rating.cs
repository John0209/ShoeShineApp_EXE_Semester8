using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Rating
	{
		public int RatingId { get; set; } // Primary Key
		public int RatingScale { get; set; } 
		// Relationship
		public ICollection<CommentStore>? Comment { get; set; }
        public ICollection<Store>? Stores { get; set; }
    }
}
