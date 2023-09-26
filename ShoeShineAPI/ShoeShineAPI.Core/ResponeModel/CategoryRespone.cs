using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.DTOs
{
	public class CategoryRespone
	{
		public int CategoryId { get; set; }// Primary Key
		public string CategoryName { get; set; } = string.Empty;
		public bool IsCategoryStatus { get; set; }
	}
}
