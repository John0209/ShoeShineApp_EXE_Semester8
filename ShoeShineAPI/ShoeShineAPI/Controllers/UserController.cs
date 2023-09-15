using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using ShoeShineAPI.Core.DTOs;
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

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDTO userRegistrationDTO)
    {
        try
        {
            var userDTO = await _user.RegisterUserAsync(userRegistrationDTO);

            var token = _user.CreateToken(userDTO.UserId);

            var response = new
            {
                Name = userDTO.UserName,
                Email = userDTO.UserEmail,
                Password = userDTO.UserPassword,
                Token = token
            };

            return Ok(response);
        }
        catch (ApplicationException ex) // Handle the specific exception thrown when email already exists
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while registering the user." });
        }
    }
}


