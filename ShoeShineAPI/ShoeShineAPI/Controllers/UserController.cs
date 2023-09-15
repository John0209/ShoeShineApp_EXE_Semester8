using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
	IUserService _user;
	IMapper _map;

	public UserController(IUserService user, IMapper map)
	{
		_user = user;
		_map = map;
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(string account, string password)
	{
		var user=await _user.CheckLogin(account,password);
		if(user != null)
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
		if (users.Any())
		{
			var userMapper = _map.Map<IEnumerable<UserDTO>>(users);
			return Ok(userMapper);
		}
		return BadRequest("User Data Is Empty");
	}
}


