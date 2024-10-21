using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Share
    {
        [Key]
        public int ShareId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public User? User { get; set; } // Navigation property

        public int PostId { get; set; } // Foreign Key
        public Post? Post { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
