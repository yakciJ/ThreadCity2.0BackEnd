using System.ComponentModel.DataAnnotations;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.DTO.User
{
    public class UserDto
    {
        public int UserId { get; set; } // Primary Key
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? FullName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public int? AvatarImgId { get; set; }
        //public Image? AvatarImage { get; set; } // Navigation property

        public int? CoverImgId { get; set; }
        //public Image? CoverImage { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; }

    }
}
