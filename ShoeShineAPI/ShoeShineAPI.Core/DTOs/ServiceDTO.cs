using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.DTOs
{
	public class ServiceDTO
	{
		public int ServiceId { get; set; }// Primary Key
		public string ServiceName { get; set; } = string.Empty;
		public float ServicePrice { get; set; }
		public bool IsServiceStatus { get; set; }
	}
}
