using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
