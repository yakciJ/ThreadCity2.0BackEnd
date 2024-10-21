using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Models.DTO;
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

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            var createdUser = await _userService.CreateUser(userDto);
            return Ok(createdUser);
        }
    }
}
