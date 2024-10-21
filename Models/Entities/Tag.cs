namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Tag
    {
        public int TagId { get; set; } // Primary Key
        public required string TagName { get; set; }

        public ICollection<LinkPostTag> LinkPostTags { get; set; }

    }
}
