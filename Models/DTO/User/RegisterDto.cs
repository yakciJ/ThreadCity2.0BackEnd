using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.DTO.User
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
