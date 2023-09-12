using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class ServiceStore
	{
		public int ServiceStoreId { get; set; }// Primary Key
		// Foreign Key
		public int ServiceId { get; set; } // Table Service
		public int StoreId { get; set; } // Table Store
		// Relationship
		public Store? Store { get; set; }
		public Service? Service { get; set; }
	}
}
