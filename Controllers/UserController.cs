using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Extensions;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.User;
using ThreadCity2._0BackEnd.Models.Entities;
using ThreadCity2._0BackEnd.Models.Mappers;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, IPostService postService, UserManager<User> userManager)
        {
            _userService = userService;
            _postService = postService;
            _userManager = userManager;
        }




        // create account
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var createdUser = await _userService.CreateUser(userDto);
            return Ok(createdUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _userService.Register(registerDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _userService.Login(loginDto);
        }



        //get all user
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }

        // get user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDtoFromUser());
        }

        [HttpGet("profile/posts")]
        [Authorize]
        public async Task<IActionResult> GetUserPost([FromQuery] PostQuery postQuery)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            var postDtos = await _postService.GetPostsByUserIdAsync(user.Id, postQuery);
            return Ok(postDtos);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserRequestDto requestDto)
        {
            var username = User.GetUsername();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var userDto = await _userService.UpdateUser(user.Id, requestDto);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // deleted user by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var response = await _userService.DeleteUser(id);
            if (response == "deleted")
            {
                return Ok();
            }
            else if (response == "notFound")
            {
                return NotFound($"User with {id}");
            }
            else
            {
                return BadRequest();
            }
        }
        // update user by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]string id, [FromBody] UpdateUserRequestDto requestDto)
        {
            try
            {
                var userDto = await _userService.UpdateUser(id, requestDto);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
