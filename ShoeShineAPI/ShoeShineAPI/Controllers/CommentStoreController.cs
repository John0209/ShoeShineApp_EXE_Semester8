using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeShineAPI.Core.DTOs;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Core.RequestModel;
using ShoeShineAPI.Service.Service.IService;
using System.Diagnostics.Metrics;

namespace ShoeShineAPI.Controllers
{
	[Route("api/comment-store")]
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

		[HttpGet("get-by-id")]
		[Route("{id:guid}")]
		public async Task<IActionResult> GetCommentById([FromRoute]Guid id)
		{
            var comment = await _comment.GetCommentById(id);
            if (comment != null)
            {
                var commentMap = _map.Map<CommentStoreRespone>(comment);
                return Ok(commentMap);
            }
            return BadRequest("Comment Data Is not exist!");
        }
        [HttpPost("create")]
		public async Task<IActionResult> CreateComment([FromBody] CommentStoreRequest commentRequest)
		{
            if (commentRequest == null)
            {
                return BadRequest();
            }
			var comment = _map.Map<CommentStore>(commentRequest);
			await _comment.CreateCommentAsync(comment);
			if(commentRequest.ImageComments != null && commentRequest.ImageComments.Any())
			{
                var images = new List<ImageComment>();
                foreach (var item in commentRequest.ImageComments)
                {
					images.Add(new ImageComment()
					{
						ImageCommentURL = item,
						CommentStoreId = comment.CommentStoreId
					});
                }

				await _comment.CreateImagesCommentAsync(images);
            }

            return CreatedAtAction(nameof(GetCommentById), new { id = comment.CommentStoreId }, commentRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] CommentStoreRequest commentRequest)
        {
            if (commentRequest == null || id != commentRequest.CommentStoreId)
            {
                return BadRequest();
            }

            var existingComment = await _comment.GetCommentById(id);
            if (existingComment == null)
            {
                return NotFound();
            }

            var comment = _map.Map<CommentStore>(commentRequest);
            await _comment.UpdateCommentAsync(comment);
            if (commentRequest.ImageComments != null && commentRequest.ImageComments.Any())
            {
                var images = new List<ImageComment>();
                foreach (var item in commentRequest.ImageComments)
                {
                    images.Add(new ImageComment()
                    {
                        ImageCommentURL = item,
                        CommentStoreId = comment.CommentStoreId
                    });
                }

                await _comment.DeleteImagesCommentByCommentStoreIdAsync(comment.CommentStoreId);
                await _comment.CreateImagesCommentAsync(images);
            }

            return NoContent();
        }
    }
}
