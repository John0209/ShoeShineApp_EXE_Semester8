using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class RatingStores
	{
		public int RatingStoresId { get; set; } // Primary Key
		public int RatingStoreScale { get; set; }
		public int StoreId { get; set; }// Table StoreEntity
		// Relationship
		public virtual Store? Store { get; set; }
	}
}
