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
		// Relationship
		public virtual Store? Store { get; set; }
	}
}
