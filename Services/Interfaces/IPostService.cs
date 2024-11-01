using Microsoft.AspNetCore.Mvc;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.Post;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface IPostService
    {
        Task<ICollection<PostDto>?> GetAllPostsAsync();
        Task<ICollection<PostDto>?> GetUserNewsfeedAsync(User user ,PostQuery postQuery);
        Task<IActionResult> UpdatePostScoresAsync();
        Task<IActionResult> UpdateUserPostScoresAsync(string userId);

        Task<PostDto> CreatePostAsync(string userId, CreatePostRequestDto requestDto);
    }
}
