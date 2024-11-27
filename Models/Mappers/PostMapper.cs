using ThreadCity2._0BackEnd.Models.DTO.Post;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post post, string userId)
        {
            return new PostDto
            {
                PostId = post.PostId,
                UserId = post.UserId,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                AuthorUserName = post.User?.UserName,
                AuthorFullName = post.User?.FullName,
                LikeCount = post.LikePosts != null ? post.LikePosts!.Count : 0,
                CommentCount = post.Comments != null ? post.Comments!.Count : 0,
                IsLiked = post.LikePosts != null ? (post.LikePosts!.FirstOrDefault(l => l.UserId == userId) != null ? true : false) : false,
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
