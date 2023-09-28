using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Errors.Model;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Enum;
using ShoeShineAPI.Infracstructure.Repositories;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class UserService : CommonAbstract<User>, IUserService
    {
        private IUnitRepository _unit;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public UserService(IUnitRepository unit, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _unit = unit;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            ProvideToken.Initialize(_configuration, _memoryCache);
        }

        public string CreateToken(Guid userId,string roles)
        {

            return ProvideToken.Instance.GenerateToken(userId,roles);
        }

        public async Task<User?> CheckLogin(string account, string password)
        {
            IEnumerable<User> users = await GetAllDataAsync();
            var checkLogin = (from u in users where u.UserAccount == account && u.UserPassword == password select u)
                             .FirstOrDefault();
            if (checkLogin != null) return checkLogin;
            return null;
        }

        public async Task<bool> RegisterUser(RegistrationRespone registrationDTO)
        {
            if (await EmailExists(registrationDTO.UserEmail))
            {
                return false;
            }

            if (registrationDTO.UserPassword != registrationDTO.ConfirmPassword)
            {
                return false;
            }

            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                UserName = registrationDTO.UserName,
                UserEmail = registrationDTO.UserEmail,
                UserPassword = registrationDTO.UserPassword,
            };

            await _unit.UserRepository.Add(newUser);

            return true;
        }

        protected override async Task<IEnumerable<User>> GetAllDataAsync()
        {
            return await _unit.UserRepository.GetAll();
        }

        public async Task<IEnumerable<User>> GetUserAsnyc()
        {
			return await GetAllDataAsync();
        }

        private async Task<bool> EmailExists(string email)
        {
            IEnumerable<User> users = await GetAllDataAsync();
            return users.Any(u => u.UserEmail == email);
        }

		public async Task<User> GetUserById(Guid userId)
		{
            var user=await _unit.UserRepository.GetById(userId);
            if (user != null) return user;
			throw new NotFoundException("UserEntity not found");
		}

        public async Task<ValidationResult> UpdateUserProfile(Guid userId, UpdateProfileRespone updateProfile)
        {
            var user = await _unit.UserRepository.GetById(userId);
            if (user == null)
            {
                return new ValidationResult("User not found");
            }

            var validationContext = new ValidationContext(updateProfile, null, null);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(updateProfile, validationContext, validationResults, true))
            {
                return validationResults.First();
            }

            try
            {
                user.UserName = updateProfile.Name;
                user.UserGender = updateProfile.Gender.ToString();
                user.UserBirthDay = updateProfile.Birthday;
                user.UserEmail = updateProfile.Email;
                user.UserPhone = updateProfile.PhoneNumber;

                _unit.UserRepository.Update(user);
                _unit.Save();

                return ValidationResult.Success;
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                return new ValidationResult($"Internal server error: {ex.Message}");
            }
        }

        public async Task<ValidationResult> UpdatePassword(Guid userId, ChangePassRespone changePass)
        {
            var user = await _unit.UserRepository.GetById(userId);
            if (user == null)
            {
                return new ValidationResult("User not found");
            }

            if (user.UserPassword != changePass.OldPassword)
            {
                return new ValidationResult("Oops! Your Password is Not Correct");
            }

            if (user.UserPassword == changePass.NewPassword)
            {
                return new ValidationResult("New password must be different from the old password");
            }

            user.UserPassword = changePass.NewPassword;

            _unit.UserRepository.Update(user);

             _unit.Save();

            return ValidationResult.Success; 
        }
    }
}
