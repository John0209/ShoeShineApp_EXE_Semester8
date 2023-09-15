using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service.IService
{
	public interface IUserService
	{
		public Task<User?> CheckLogin(string account, string password);
		public string CreateToken(Guid userId);
		public Task<IEnumerable<User>> GetUserAsnyc();
	}
}
