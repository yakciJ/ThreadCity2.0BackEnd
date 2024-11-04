using System.ComponentModel.DataAnnotations;

namespace ThreadCity2._0BackEnd.Helpers
{
    public class SearchPostsQuery : PostQuery
    {
        [Required(ErrorMessage = "Thuật ngữ tìm kiếm không được để trống")]
        public required string SearchTerm { get; set; }
    }
}
