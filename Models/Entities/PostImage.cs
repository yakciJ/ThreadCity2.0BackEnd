using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class PostImage
    {
        [Key]
        public int PostImgId { get; set; } // Primary Key
        public int PostId { get; set; } // Foreign Key
        public Post? Post { get; set; } // Navigation property

        public int ImageId { get; set; } // Foreign Key
        public Image? Image { get; set; } // Navigation property

    }
}
