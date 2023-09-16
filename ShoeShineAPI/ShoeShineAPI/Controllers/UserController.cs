using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeShineAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly IMapper _map;
        private readonly IMemoryCache _memoryCache;

        public UserController(IUserService user, IMapper map, IMemoryCache memoryCache)
        {
            _user = user;
            _map = map;
            _memoryCache = memoryCache; 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string account, string password)
        {
            var user = await _user.CheckLogin(account, password);
            if (user != null)
            {
                var token = _user.CreateToken(user.UserId);
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _user.GetUserAsnyc();
            if (users != null)
            {
                var userMapper = _map.Map<IEnumerable<UserDTO>>(users);
                if (userMapper.Any())
                {
                    return Ok(userMapper);
                }
            }
            return BadRequest("User Data Is Empty");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO registrationDTO)
        {
            bool registrationResult = await _user.RegisterUser(registrationDTO);
            if (registrationResult)
            {
                // Registration successful
                var token = _user.CreateToken(Guid.NewGuid());
                _memoryCache.Remove("UserCacheKey");
                return Ok(new { Token = token, UserName = registrationDTO.UserName, UserEmail = registrationDTO.UserEmail, UserPassword = registrationDTO.UserPassword });
            }
            return BadRequest("Registration failed. Email already exists or passwords do not match.");
        }
    }
}
