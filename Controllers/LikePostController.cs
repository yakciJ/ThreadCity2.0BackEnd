using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Extensions;
using ThreadCity2._0BackEnd.Models.Entities;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LikePostController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IPostService _postService;

        public LikePostController(UserManager<User> userManager, IPostService postService)
        {
            _userManager = userManager;
            _postService = postService;
        }

        [HttpPut("{postId}")]
        [Authorize]
        public async Task<IActionResult> LikeOrDislikePost([FromRoute] int postId)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return await _postService.LikeOrDislikePostAsync(postId, user.Id);
        }
    }
}
