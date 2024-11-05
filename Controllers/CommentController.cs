using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Extensions;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.Comment;
using ThreadCity2._0BackEnd.Models.Entities;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;

        public CommentController(ICommentService commentService, UserManager<User> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetCommentsByPostId([FromRoute] int postId, [FromQuery] CommentQuery commentQuery)
        {
            var CommentDto = await _commentService.GetCommentsByPostIdAsync(postId, commentQuery);
            return Ok(CommentDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequestDto requestDto)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            var CommentDto = await _commentService.CreateCommentAsync(user.Id, requestDto);
            return Ok(CommentDto);
        }
    }
}
