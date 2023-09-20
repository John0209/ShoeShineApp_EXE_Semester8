using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class RatingStoresEntity
	{
		public int RatingStoresId { get; set; } // Primary Key
		public int RatingStoreScale { get; set; }
		public int StoreId { get; set; }// Table StoreEntity
		// Relationship
		public virtual StoreEntity? Store { get; set; }
	}
}
