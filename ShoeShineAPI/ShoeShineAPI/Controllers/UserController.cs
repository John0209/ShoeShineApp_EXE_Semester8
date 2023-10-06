using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.ResponeModel;
using ShoeShineAPI.Enum;
using ShoeShineAPI.Service.Service;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoeShineAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly IMapper _map;
        private readonly IMemoryCache _memoryCache;
        private readonly IRoleService _role;

		public UserController(IUserService user, IMapper map, IMemoryCache memoryCache, IRoleService role)
		{
			_user = user;
			_map = map;
			_memoryCache = memoryCache;
			_role = role;
		}

		[HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _user.CheckLogin(email, password);
            if (user != null)
            {
                var role = await _role.GetRoleById(user.RoleId);
                var token = _user.CreateToken(user.UserId,role.RoleName);
                return Ok(token);
            }
            return BadRequest("Login failed");
        }

        [HttpGet("get-new-guid")]
        public IActionResult GetGuid()
        {
            var guid = Guid.NewGuid();
            return Ok(guid);
        }
       
		[Authorize(Roles = EnumClass.RoleNames.Admin)]
		[HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var users = await _user.GetUserAsnyc();
            if (users != null)
            {
                var userMapper = _map.Map<IEnumerable<UserRespone>>(users);
                if (userMapper.Any())
                {
                    return Ok(userMapper);
                }
            }
            return BadRequest("UserEntity Data Is Empty");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRespone registrationDTO)
        {
            bool registrationResult = await _user.RegisterUser(registrationDTO);
            if (registrationResult)
            {
                return Ok("Register Successfully");
            }
            return BadRequest("Registration failed. Email already exists or passwords do not match.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
            try
            {
                var user = await _user.GetUserById(userId);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                EnumClass.GenderEnum gender;
                if (EnumClass.GenderEnum.TryParse(user.UserGender, out gender))
                {
                    var userProfileDto = new UserProfileRespone
                    {
                        Name = user.UserName,
                        Gender = gender,
                        Birthday = user.UserBirthDay,
                        Email = user.UserEmail,
                        PhoneNumber = user.UserPhone,
                        Password = user.UserPassword
                    };

                    return Ok(userProfileDto);
                }
                else
                {
                    return BadRequest("Invalid gender value");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUserProfile(Guid userId, UpdateProfileRespone updateProfile)
        {
            var validationResult = await _user.UpdateUserProfile(userId, updateProfile);

            if (validationResult == ValidationResult.Success)
            {
                return Ok("User profile updated successfully");
            }
            else
            {
                return BadRequest(validationResult.ErrorMessage);
            }
        }

        [HttpPut("{userId}/update-password")]
        public async Task<IActionResult> UpdatePassword(Guid userId, ChangePassRespone changePass)
        {
            try
            {
                var validationResult = await _user.UpdatePassword(userId, changePass);

                if (validationResult == ValidationResult.Success)
                {
                    return Ok("Password updated successfully");
                }
                else
                {
                    return BadRequest(validationResult.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}
