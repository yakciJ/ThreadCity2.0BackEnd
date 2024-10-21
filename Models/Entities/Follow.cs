using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Follow
    {
        [Key] // primary key
        public int FollowId { get; set; } // Primary Key

        public int FollowerUserId { get; set; } // Foreign Key
        public User? FollowerUser { get; set; } // Navigation property

        public int FollowedUserId { get; set; } // Foreign Key
        public User? FollowedUser { get; set; } // Navigation property

    }
}
