namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Comment
    {
        public int CommentId { get; set; } // Primary Key
        public string? UserId { get; set; } // Foreign Key
        public User? User { get; set; } // Navigation property

        public int PostId { get; set; } // Foreign Key
        public Post? Post { get; set; } // Navigation property

        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<LikeComment>? LikeComments { get; set; }

    }
}
