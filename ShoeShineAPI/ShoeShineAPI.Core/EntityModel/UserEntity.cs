using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.Model
{
	public class UserEntity
	{
		public Guid UserId { get; set; }// Primary Key
		public string UserName { get; set; } = string.Empty;
		public string UserPhone { get; set; } = string.Empty;
		public string UserEmail { get; set; } = string.Empty;
		public string UserAddress { get; set; } = string.Empty;
		public string UserAccount { get; set; } = string.Empty;
		public string UserPassword { get; set; } = string.Empty;
		public bool IsUserStatus { get; set; } =true;
		// Foreign Key
		public int RoleId { get; set; } // Table RoleEntity
		// Relationship
		public ICollection<CommentStoreEntity>? Comments { get; set; }
		public virtual RoleEntity? Role { get; set; }

	}
}
