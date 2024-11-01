using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Extensions;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.Post;
using ThreadCity2._0BackEnd.Models.Entities;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostController(IPostService postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var postDtos = await _postService.GetAllPostsAsync();
            return Ok(postDtos);
        }

        [HttpGet("newsfeed")]
        [Authorize]
        public async Task<IActionResult> GetUserNewsfeed([FromQuery] PostQuery postQuery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            var postDtos = await _postService.GetUserNewsfeedAsync(user, postQuery);
            return Ok(postDtos);
        }

        [HttpPut("update-posts-scores")]
        [Authorize]
        public async Task<IActionResult> UpdatePostScores()
        {
            var result = await _postService.UpdatePostScoresAsync();
            return result;
        }

        [HttpPut("update-user-post-scores")]
        [Authorize]
        public async Task<IActionResult> UpdateUserPostScores()
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _postService.UpdateUserPostScoresAsync(user.Id);
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }
            var postDto = await _postService.CreatePostAsync(user.Id, requestDto);
            return Ok(postDto);
        }
    }
}
