using ThreadCity2._0BackEnd.Models.DTO.Post;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                UserId = post.UserId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                AuthorUserName = post.User?.UserName,
                AuthorFullName = post.User?.FullName,
            };
        }

        public static Post ToPostFromCreate(this CreatePostRequestDto requestDto)
        {
            return new Post
            {
                Title = requestDto.Title,
                Content = requestDto.Content
            };
        }
    }
}
