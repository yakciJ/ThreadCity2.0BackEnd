namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class UserPostScore
    {
        public string? UserId { get; set; }
        public User? User { get; set; }  
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public double RelevanceScore { get; set; }  
    }
}
