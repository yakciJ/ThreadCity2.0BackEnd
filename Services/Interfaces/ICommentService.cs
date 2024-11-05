
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.Comment;

namespace ThreadCity2._0BackEnd.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentDto> CreateCommentAsync(string userId, CreateCommentRequestDto requestDto);
        Task<ICollection<CommentDto>?> GetCommentsByPostIdAsync(int postId, CommentQuery commentQuery);
    }
}
