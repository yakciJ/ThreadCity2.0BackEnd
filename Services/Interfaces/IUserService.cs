using ThreadCity2._0BackEnd.Models.DTO;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserDto> CreateUser(CreateUserDto createUserDto);
    }
}
