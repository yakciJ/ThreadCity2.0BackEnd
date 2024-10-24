using ThreadCity2._0BackEnd.Models.DTO.User;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserDto> CreateUser(CreateUserDto createUserDto);
        Task<List<UserDto>> GetAllUser();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> GetUserByName(string name);
        Task<string> DeleteUser(int id);
        Task<UserDto> UpdateUser(int id, UserDto userDto);
    }
}
