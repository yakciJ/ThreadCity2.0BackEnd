using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.DTO.User
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
