using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThreadCity2._0BackEnd.Data;
using ThreadCity2._0BackEnd.Models.DTO.User;
using ThreadCity2._0BackEnd.Models.Entities;
using ThreadCity2._0BackEnd.Models.Mappers;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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

        public async Task<string> DeleteUser(string id)
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
        public async Task<UserDto> GetUserById(string id)
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

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);
            if (user == null)
            {
                return new UnauthorizedObjectResult("Invalid Username!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return new UnauthorizedObjectResult("Username not found and/or password incorrect");
            }

            return new OkObjectResult(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                });

        }


        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(user, registerDto.Password);

                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");

                    if (roleResult.Succeeded)
                    {
                        return new OkObjectResult( 
                            new NewUserDto
                            {
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            });
                    }
                    else
                    {
                        return new ObjectResult(roleResult.Errors) { StatusCode = 500 };
                    }
                }
                else
                {
                    return new ObjectResult(createUser.Errors) { StatusCode = 500 };
                }
            }
            catch (Exception e)
            {
                return new ObjectResult(e) { StatusCode = 500 };
            }
        }


        public async Task<UserDto> UpdateUser(string id, UserDto userDto)
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
