using ShoeShineAPI.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public bool IsCategoryStatus { get; set; }
	}
}
