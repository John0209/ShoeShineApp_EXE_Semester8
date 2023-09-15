using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
	IUserService _user;

	public UserController(IUserService user)
	{
		_user = user;
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
	//[HttpGet]
	//public IActionResult GetGuid()
	//{
	//	var guid = Guid.NewGuid();
	//	return Ok(guid);
	//}
}


