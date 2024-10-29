using ThreadCity2._0BackEnd.Models.DTO.Post;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface IPostService
    {
        ICollection<PostDto>? GetAllPosts();

        Task<PostDto> CreatePostAsync(string userId, CreatePostRequestDto requestDto);
    }
}
