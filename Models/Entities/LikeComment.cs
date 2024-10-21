using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class LikeComment
    {
        [Key]
        public int LikeCmtId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public User? User { get; set; } // Navigation property

        public int CommentId { get; set; } // Foreign Key
        public Comment? Comment { get; set; } // Navigation property

    }
}
