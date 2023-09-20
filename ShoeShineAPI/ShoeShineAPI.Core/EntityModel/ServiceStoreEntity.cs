using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class ServiceStoreEntity
	{
		public int ServiceStoreId { get; set; }// Primary Key
		// Foreign Key
		public int ServiceId { get; set; } // Table Service
		public int StoreId { get; set; } // Table StoreEntity
		// Relationship
		public virtual StoreEntity? Store { get; set; }
		public virtual ServiceEntity? Service { get; set; }
	}
}
