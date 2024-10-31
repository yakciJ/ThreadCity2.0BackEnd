using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class LikeComment
    {
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }

        public int CommentId { get; set; }
        public Comment? Comment { get; set; }

    }
}
