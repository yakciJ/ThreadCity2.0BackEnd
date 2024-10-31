namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class PostScore
    {
        public int PostScoreId { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public double TimeScore { get; set; }
        public double PopularityScore { get; set; }

    }
}
