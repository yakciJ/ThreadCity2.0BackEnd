using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Models.DTO.Post
{
    public class CreatePostRequestDto
    {
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
    }
}
