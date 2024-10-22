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
                Password = user.Password,
                Email = user.Email
            };
        }

        public static UserDto ToUserDtoFromUser(this User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone,
                AvatarImgId = user.AvatarImgId,
                AvatarImage = user.AvatarImage,
                CoverImgId = user.CoverImgId,
                CoverImage = user.CoverImage,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
