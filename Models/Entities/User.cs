using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class User : IdentityUser
    {
        //[Key] // primary key
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; } // Primary Key
        public string? FullName { get; set; }
        public int? AvatarImgId { get; set; }
        public Image? AvatarImage { get; set; }

        public int? CoverImgId { get; set; }
        public Image? CoverImage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? Bio { get; set; }

        public ICollection<UserPostScore>? UserPostScores { get; set; }
        public ICollection<Follow>? Followers { get; set; }
        public ICollection<Follow>? Following { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<LikePost>? LikePosts { get; set; }
        public ICollection<SeenPost>? SeenPosts { get; set; }
        public ICollection<Share>? Shares { get; set; }
        public ICollection<LikeComment>? LikeComments { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}

