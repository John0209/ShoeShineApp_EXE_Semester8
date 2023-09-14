using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Service
	{
		public int ServiceId { get; set; }// Primary Key
		public string ServiceName { get; set; } = string.Empty;
		public float ServicePrice { get; set; }
		public bool IsServiceStatus { get; set; }
		// Relationship
		public ICollection<ServiceStore>? ServiceStores { get; set; }
	}
}
