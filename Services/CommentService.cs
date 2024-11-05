using Microsoft.EntityFrameworkCore;
using ThreadCity2._0BackEnd.Data;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.Comment;
using ThreadCity2._0BackEnd.Models.Mappers;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<CommentDto>?> GetCommentsByPostIdAsync(int postId, CommentQuery commentQuery)
        {
            int skipNumber = (commentQuery.PageNumber - 1) * commentQuery.PageSize;
            var comments = await _context.Comments
                .Include(c => c.User)
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.CreatedAt)
                .Skip(skipNumber)
                .Take(commentQuery.PageSize)
                .Select(c => c.ToCommentDto())
                .ToListAsync();
            return comments;
        }
    }
}
