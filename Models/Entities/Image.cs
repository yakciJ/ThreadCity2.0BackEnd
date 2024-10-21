namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Image
    {
        public int ImageId { get; set; } // Primary Key
        public string Url { get; set; }

        public ICollection<PostImage> PostImages { get; set; }

    }
}
