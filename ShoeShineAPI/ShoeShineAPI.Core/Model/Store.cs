using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Store
	{
		public Guid StoreId { get; set; }
		public string StoreName { get; set; } =string.Empty;
		public string StoreAddress { get; set; } =string.Empty;
		public bool IsStoreStatus { get; set; } = true;
		//Foreign Key
		public int ImageId { get; set; } // Table Image
	}
}
