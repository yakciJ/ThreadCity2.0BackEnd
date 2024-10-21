using System.Runtime.CompilerServices;
using ThreadCity2._0BackEnd.Models.DTO;
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
    }
}
