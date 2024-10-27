using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class SeenPost
    {
        [Key]
        public int SeenId { get; set; } // Primary Key
        public string? UserId { get; set; } // Foreign Key
        public User? User { get; set; } // Navigation property

        public int PostId { get; set; } // Foreign Key
        public Post? Post { get; set; } // Navigation property

        public DateTime SeenAt { get; set; } = DateTime.Now;

    }
}
