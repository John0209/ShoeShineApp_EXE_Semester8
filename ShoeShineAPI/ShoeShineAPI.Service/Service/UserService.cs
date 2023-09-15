using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using ShoeShineAPI.Core.DTOs;
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
		private readonly IConfiguration _configuration ;
		private readonly IMemoryCache _memoryCache;
		public UserService(IUnitRepository unit, IConfiguration configuration, IMemoryCache memoryCache)
		{
			_unit = unit;
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
			ProvideToken.Initialize(_configuration, _memoryCache);
		}

		public string CreateToken(Guid userId)
		{
			return ProvideToken.Instance.GenerateToken(userId);
		}
		public async Task<User?> CheckLogin(string account, string password)
		{
			IEnumerable<User> users =await GetAllDataAsync();
			var checkLogin= (from u in users where u.UserAccount== account && u.UserPassword==password select u)
							.FirstOrDefault();
			if(checkLogin != null) return checkLogin;
			return null;
		}


        public async Task<UserDTO> RegisterUserAsync(UserRegistrationDTO userRegistrationDTO)
        {
            var existingUser = await _unit.UserRepository.GetUserByEmailAsync(userRegistrationDTO.UserEmail);
            if (existingUser != null)
            {
                throw new ApplicationException("User with this email already exists.");
            }

            if (userRegistrationDTO.UserPassword != userRegistrationDTO.ConfirmPassword)
            {
                throw new ApplicationException("Passwords do not match.");
            }

            var newUser = new User
            {
                UserName = userRegistrationDTO.UserName,
                UserEmail = userRegistrationDTO.UserEmail,
                UserPassword = userRegistrationDTO.UserPassword,
                IsUserStatus = true
            };

            await _unit.UserRepository.Add(newUser);

            var userDTO = new UserDTO
            {
                UserId = newUser.UserId,
                UserName = newUser.UserName,
                UserEmail = newUser.UserEmail,
                UserPassword = newUser.UserPassword,
                IsUserStatus = newUser.IsUserStatus
            };

            return userDTO;
        }

        protected override async Task<IEnumerable<User>> GetAllDataAsync()
		{
			return await _unit.UserRepository.GetAll();
		}
	}
}
