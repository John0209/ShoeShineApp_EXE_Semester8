using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class ServiceEntity
	{
		public int ServiceId { get; set; }// Primary Key
		public string ServiceName { get; set; } = string.Empty;
		public float ServicePrice { get; set; }
		public bool IsServiceStatus { get; set; }
		// Relationship
		public ICollection<ServiceStoreEntity>? ServiceStores { get; set; }
	}
}
