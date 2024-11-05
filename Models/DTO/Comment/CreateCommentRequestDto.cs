using System.ComponentModel.DataAnnotations;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Models.DTO.Comment
{
    public class CreateCommentRequestDto
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Chưa nhập bình luận")] 
        
        public required string Content { get; set; }
    }
}
