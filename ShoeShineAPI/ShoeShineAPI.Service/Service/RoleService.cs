using SendGrid.Helpers.Errors.Model;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
	public class RoleService : CommonAbstract<RoleEntity>, IRoleService
	{
		IUnitRepository _unit;

		public RoleService(IUnitRepository unit)
		{
			_unit = unit;
		}

		public async Task<RoleEntity> GetRoleById(int roleId)
		{
			var role= await _unit.RoleRepository.GetById(roleId);
			if (role != null) return role;
			throw new NotFoundException("role not found");
		}

		public async Task<IEnumerable<RoleEntity>> GetRolesAsync()
		{
			return await GetAllDataAsync();
		}

		protected override Task<IEnumerable<RoleEntity>> GetAllDataAsync()
		{
			return _unit.RoleRepository.GetAll();
		}
	}
}
