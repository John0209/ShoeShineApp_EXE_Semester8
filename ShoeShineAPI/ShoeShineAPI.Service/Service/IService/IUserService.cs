using ShoeShineAPI.Core.DTOs;
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
		public string CreateToken(Guid userId, string roles);
		public Task<IEnumerable<User>> GetUserAsnyc();
        Task<bool> RegisterUser(RegistrationDTO registrationDTO);
		public Task<User> GetUserById(Guid userId);

    }
}
