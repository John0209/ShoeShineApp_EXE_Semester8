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
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Text;

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

        public async Task<User?> CheckLogin(string email, string password)
        {
            IEnumerable<User> users = await GetAllDataAsync();
            var checkLogin = (from u in users where u.UserEmail == email && u.UserPassword == password select u)
                             .FirstOrDefault();
            if (checkLogin != null) return checkLogin;
            return null;
        }

        public async Task<bool> RegisterUser(RegistrationRespone registrationDTO, EnumClass.RoleEnum role)
        {
            if (await EmailExists(registrationDTO.UserEmail)) return false;

            if (registrationDTO.UserPassword != registrationDTO.ConfirmPassword)return false;

            // Gán RoleId t? EnumClass.RoleEnum.Customer
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                UserName = registrationDTO.UserName,
                UserEmail = registrationDTO.UserEmail,
                UserPassword = registrationDTO.UserPassword,
                //RoleId = (int)EnumClass.RoleEnum.Customer
                RoleId =(int) role,
                UserRegisterDate= DateTime.Now,
            };
            await _unit.UserRepository.Add(newUser);
            if(_unit.Save() >0)
                return true;
            return false;
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

		public async Task<User?> GetUserById(Guid userId)
		{
            var user=await _unit.UserRepository.GetById(userId);
            /*if (user != null)*/ return user;
			/*throw new NotFoundException("UserEntity not found");*/
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
                user.UserRegisterDate=DateTime.Now;
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

        public async Task RemoveAllUsers()
        {
            var users = await _unit.UserRepository.GetAll();
            if(users != null && users.Any())
            {
                _unit.UserRepository.RemoveRange(users);
                _unit.Save();
            }
        }

        public async Task<bool> DeleteUserById(Guid userId)
        {
            var user = await _unit.UserRepository.GetById(userId);
            if (user != null)
            {
                user.IsUserStatus = false;
                _unit.UserRepository.Update(user);
                var result = _unit.Save();
                if (result > 0) return true;
            }
            return false;
        }
        private async Task<User?> CheckEmail(string email)
        {
            IEnumerable<User> users = await GetAllDataAsync();
            return users.Where(x=> x.UserEmail == email).FirstOrDefault();
        }
        public async Task<bool> RecoverPassword(string email)
        {
            var m_user = await CheckEmail(email);
            if (m_user != null)
            {
                // random password với độ dài 8 ký tự
                int lengthOfRandomString = 8;
                string randomPass = GenerateRandomString(lengthOfRandomString);
                // set up send meail
                string sendto = m_user.UserEmail;
                string subject = "Recover Password of Account " + m_user.UserName;
                string content = "Your New Password is " + randomPass;
                //set new password
                ChangePassRespone pass = new ChangePassRespone();
                pass.OldPassword = m_user.UserPassword;
                pass.NewPassword = randomPass;
                //update password
                await UpdatePassword(m_user.UserId,pass);
                string _gmail = "nguyentuanvu020901@gmail.com";
                string _pass = "fhnwtwqisekdqzcr";
                try
                {

                    MailMessage mail = new MailMessage();
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    //set property for email you want to send
                    mail.From = new MailAddress(_gmail);
                    mail.To.Add(sendto);
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = content;
                    mail.Priority = MailPriority.High;
                    //set smtp port
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    //set gmail pass sender
                    smtp.Credentials = new NetworkCredential(_gmail, _pass);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
                return false;
        }
        public string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return stringBuilder.ToString();
        }

    }
}
