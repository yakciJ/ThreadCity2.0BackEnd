using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.DTO.Post
{
    public class CreatePostRequestDto
    {
        [Required(ErrorMessage = "Hãy nhập tiêu đề trước khi đăng")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Hãy nhập nội dung trước khi đăng")]
        public required string Content { get; set; }
    }
}
