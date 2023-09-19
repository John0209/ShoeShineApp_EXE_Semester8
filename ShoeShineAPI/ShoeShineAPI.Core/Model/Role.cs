using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class Role
	{
		public int RoleId { get; set; }// Primary Key
		public string RoleName { get; set; } = string.Empty;
		// Relationship
		public ICollection<User>? Users { get; set; }
	}
}
