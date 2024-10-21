using ThreadCity2._0BackEnd.Models.DTO;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface IPostService
    {
        ICollection<PostDto>? GetAllPosts();
    }
}
