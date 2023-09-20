using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.DTOs
{
	public class UserRespone
	{
		public Guid UserId { get; set; }// Primary Key
		public string UserName { get; set; } = string.Empty;
		public string UserPhone { get; set; } = string.Empty;
		public string UserEmail { get; set; } = string.Empty;
		public string UserAddress { get; set; } = string.Empty;
		public string UserAccount { get; set; } = string.Empty;
		public string UserPassword { get; set; } = string.Empty;
		public bool IsUserStatus { get; set; } = true;
	}
}
