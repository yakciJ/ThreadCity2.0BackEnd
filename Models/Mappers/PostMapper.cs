using ThreadCity2._0BackEnd.Models.DTO;
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
                CreatedAt = post.CreatedAt
            };
        }
    }
}
