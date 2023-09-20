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
		public Task<UserEntity?> CheckLogin(string account, string password);
		public string CreateToken(Guid userId, string roles);
		public Task<IEnumerable<UserEntity>> GetUserAsnyc();
        Task<bool> RegisterUser(RegistrationRespone registrationDTO);
		public Task<UserEntity> GetUserById(Guid userId);

    }
}
