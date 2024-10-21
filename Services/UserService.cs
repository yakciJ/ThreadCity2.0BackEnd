using ThreadCity2._0BackEnd.Data;
using ThreadCity2._0BackEnd.Models.DTO;
using ThreadCity2._0BackEnd.Models.Mappers;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUserDto> CreateUser(CreateUserDto userDto)
        {
            // Create a user
            await _context.AddAsync(userDto.ToUserFromCreate());
            await _context.SaveChangesAsync();
            return userDto;
        }
    }
}
