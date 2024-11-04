using System.Runtime.CompilerServices;
using ThreadCity2._0BackEnd.Models.DTO.User;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromCreate(this CreateUserDto user)
        {
            return new User
            {
                UserName = user.UserName,
                PasswordHash = user.Password,
                Email = user.Email
            };
        }

        public static UserDto ToUserDtoFromUser(this User user)
        {
            return new UserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                AvatarImgId = user.AvatarImgId,
                CoverImgId = user.CoverImgId,
                CreatedAt = user.CreatedAt
            };
        }

        public static User ToUserFromUserDto(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.UserId,
                UserName = userDto.UserName,
                FullName = userDto.FullName,
                Email = userDto.Email,
                PhoneNumber = userDto.Phone,
                AvatarImgId = userDto.AvatarImgId,
                CoverImgId = userDto.CoverImgId,
                CreatedAt = userDto.CreatedAt
            };
        }
    }
}
