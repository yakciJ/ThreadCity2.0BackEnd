using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Models.DTO.User;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserDto> CreateUser(CreateUserDto createUserDto);
        Task<List<UserDto>> GetAllUser();
        Task<UserDto> GetUserById(string id);
        Task<UserDto> GetUserByName(string name);
        Task<string> DeleteUser(string id);
        Task<UserDto> UpdateUser(string id, UserDto userDto);
        Task<IActionResult> Register(RegisterDto registerDto);
        Task<IActionResult> Login(LoginDto loginDto);
    }
}
