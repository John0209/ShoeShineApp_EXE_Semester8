using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.ResponeModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        Task<bool> RegisterUser(RegistrationRespone registrationDTO);
		public Task<User> GetUserById(Guid userId);
        Task<ValidationResult> UpdateUserProfile(Guid userId, UpdateProfileRespone updateProfile);
		public Task<ValidationResult> UpdatePassword(Guid userId, ChangePassRespone changePass);
    }
}
