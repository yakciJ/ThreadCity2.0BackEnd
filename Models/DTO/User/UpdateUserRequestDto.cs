using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.DTO.User
{
    public class UpdateUserRequestDto
    {
        public string? FullName { get; set; }
        [EmailAddress(ErrorMessage = "Hãy nhập đúng địa chỉ Email")]
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public int AvatarImgId { get; set; }
        public int CoverImgId { get; set; }

        public string? Bio { get; set; }

    }
}
