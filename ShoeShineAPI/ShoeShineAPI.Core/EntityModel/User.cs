using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class User
	{
		public Guid UserId { get; set; }// Primary Key
		public string UserName { get; set; } = string.Empty;
		public string UserPhone { get; set; } = string.Empty;
		public string UserEmail { get; set; } = string.Empty;
		public string UserAddress { get; set; } = string.Empty;
		public string UserAccount { get; set; } = string.Empty;
		public string UserPassword { get; set; } = string.Empty;
		public string UserGender { get; set; } = string.Empty;
        public DateTime UserBirthDay { get; set; }
        public bool IsUserStatus { get; set; } = true;
        // Foreign Key
        public int RoleId { get; set; } // Table Role
		// Relationship
		public ICollection<CommentStore>? Comments { get; set; }
		public virtual Role? Role { get; set; }

	}
}
