using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface IRoleService
	{
		public Task<Role> GetRoleById(int roleId);
		public Task<IEnumerable<Role>> GetRolesAsync();
	}
}
