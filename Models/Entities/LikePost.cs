using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class LikePost
    {
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }

        public int PostId { get; set; }
        public Post? Post { get; set; }

    }
}
