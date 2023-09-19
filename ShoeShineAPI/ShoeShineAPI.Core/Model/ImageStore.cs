using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class ImageStore
	{
		public int ImageStoreId { get; set; }// Primary Key
		public string ImageURL { get; set; }= string.Empty;
		// Foreign Key
		public int StoreId { get; set; } // Table Store
		// Relationship
		public virtual Store? Store { get; set; }
	}
}
