using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class LinkPostTag
    {
        [Key]
        public int LinkId { get; set; } // Primary Key
        public int PostId { get; set; } // Foreign Key
        public Post? Post { get; set; } // Navigation property

        public int TagId { get; set; } // Foreign Key
        public Tag? Tag { get; set; } // Navigation property
    }
}
