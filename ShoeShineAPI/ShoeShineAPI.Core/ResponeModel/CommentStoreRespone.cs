using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.DTOs
{
	public class CommentStoreRespone
	{
		public int CommentStoreId { get; set; }// Primary Key
		public string Content { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty; 
		public string StoreName { get; set; } = string.Empty;
		public List<string>? ImageComments { get; set; }
		public int RatingComment { get; set; }
	}
}
