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
	public class UserService : CommonAbstract<User>, IUserService
	{
		IUnitRepository _unit;

		public UserService(IUnitRepository unit)
		{
			_unit = unit;
		}
		public async Task<User?> CheckLogin(string account, string password)
		{
			List<User> userList =await GetAllData();
			var checkLogin= (from u in userList where u.UserAccount== account && u.UserPassword==password select u)
							.FirstOrDefault();
			if(checkLogin != null) return checkLogin;
			return null;
		}

		protected override async Task<List<User>> GetAllData()
		{
			return await _unit.UserRepository.GetAll();
		}
	}
}
