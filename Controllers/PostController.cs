using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Extensions;
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
