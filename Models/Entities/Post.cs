using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Post
    {
        [Key] // primary key
        public int PostId { get; set; } // Primary Key
        public string? UserId { get; set; } // Foreign Key
        public User? User { get; set; } // Navigation property
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public PostScore? PostScore { get; set; }

        public ICollection<PostImage>? PostImages { get; set; }
        public ICollection<LinkPostTag>? LinkPostTags { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<LikePost>? LikePosts { get; set; }
        public ICollection<SeenPost>? SeenPosts { get; set; }
        public ICollection<Share>? Shares { get; set; }

    }
}
