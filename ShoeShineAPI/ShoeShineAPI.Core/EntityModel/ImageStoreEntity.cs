using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class ImageStoreEntity
	{
		public int ImageStoreId { get; set; }// Primary Key
		public string ImageURL { get; set; }= string.Empty;
		// Foreign Key
		public int StoreId { get; set; } // Table StoreEntity
		// Relationship
		public virtual StoreEntity? Store { get; set; }
	}
}
