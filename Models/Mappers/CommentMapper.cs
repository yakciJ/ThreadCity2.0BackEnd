using System.ComponentModel.Design;
using ThreadCity2._0BackEnd.Models.DTO.Comment;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                CommentId = comment.CommentId,
                UserId = comment.UserId,
                AuthorUserName = comment.User.UserName,
                PostId = comment.PostId,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentRequestDto comment)
        {
            return new Comment
            {
                PostId = comment.PostId,
                Content = comment.Content
            };
        }

    }
}
