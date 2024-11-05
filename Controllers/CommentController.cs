using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetCommentsByPostId([FromRoute] int postId, [FromQuery] CommentQuery commentQuery)
        {
            var CommentDto = await _commentService.GetCommentsByPostIdAsync(postId, commentQuery);
            return Ok(CommentDto);
        }
    }
}
