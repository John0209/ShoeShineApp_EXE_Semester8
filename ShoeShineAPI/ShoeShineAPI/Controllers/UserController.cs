using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoeShineAPI.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetUser()
		{
			return Ok();
		}
	}
}
