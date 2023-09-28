using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Service.IService;

namespace ShoeShineAPI.Controllers
{
	[Route("api/comment-stores")]
	[ApiController]
	public class CommentStoreController : Controller
	{
		ICommentStoreService _comment;
		IMapper _map;

		public CommentStoreController(ICommentStoreService comment, IMapper map)
		{
			_comment = comment;
			_map = map;
		}
		[HttpGet("get-comment-of-by-store-id")]
		public async Task<IActionResult> GetCommentByStoreId(int storeId)
		{
			var comment = await _comment.GetCommentByStoreId(storeId);
			if (comment.Any())
			{
				var commentMap = _map.Map<IEnumerable<CommentStoreRespone>>(comment);
				return Ok(commentMap);
			}
			return BadRequest("Comment Data Is Empty !!!");
		}
		[HttpGet("get-all")]
		public async Task<IActionResult> GetAll()
		{
			var comment = await _comment.GetCommentAsync();
			if (comment.Any())
			{
				var commentMap = _map.Map<IEnumerable<CommentStoreRespone>>(comment);
				return Ok(commentMap);
			}
			return BadRequest("Comment Data Is Empty");
		}
	}
}
