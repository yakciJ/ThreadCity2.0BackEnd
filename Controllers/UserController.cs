using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Models.DTO.User;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // create account
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var createdUser = await _userService.CreateUser(userDto);
            return Ok(createdUser);
        }

        //get all user
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }

        // get user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
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

        // deleted user by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            try
            {
                await _userService.UpdateUser(id, userDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
