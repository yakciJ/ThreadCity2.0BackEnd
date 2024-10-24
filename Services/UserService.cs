using Microsoft.EntityFrameworkCore;
using ThreadCity2._0BackEnd.Data;
using ThreadCity2._0BackEnd.Models.DTO.User;
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
            try
            {
                await _context.AddAsync(userDto.ToUserFromCreate());
                await _context.SaveChangesAsync();
                return userDto;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<string> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return ("notFound");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return ("deleted");
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers.Select(user => user.ToUserDtoFromUser()).ToList();
        }

        // get user by id
        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found.");
            }
            return user.ToUserDtoFromUser();
        }

        public Task<UserDto> GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> UpdateUser(int id, UserDto userDto)
        {
            if (id != userDto.UserId)
            {
                throw new Exception("Id mismatch");
            }
            else if (userDto == null)
            {
                throw new Exception("No input data");
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                _context.Users.Update(userDto.ToUserFromUserDto());
                await _context.SaveChangesAsync();
                return userDto;
            }
        }
    }
}
