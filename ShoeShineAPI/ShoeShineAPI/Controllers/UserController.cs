using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IUserService _user;

		public UserController(IUserService user)
		{
			_user = user;
		}

		[HttpPost]
		public IActionResult CheckLogin(string account, string password)
		{
			return Ok();
		}
	}
}
