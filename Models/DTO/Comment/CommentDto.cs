using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.DTO.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; } // Primary Key
        public string? UserId { get; set; }
        public string AuthorUserName { get; set; } = string.Empty;
        public int PostId { get; set; } // Foreign Key

        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
