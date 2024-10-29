namespace ThreadCity2._0BackEnd.Models.DTO.Post
{
    public class PostDto
    {
        public string? UserId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? AuthorUserName { get; set; }
        public string? AuthorFullName { get; set; }
    }
}
