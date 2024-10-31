using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreadCity2._0BackEnd.Models.Entities
{
    public class Follow
    {
        public string FollowerUserId { get; set; } = string.Empty;
        public User? FollowerUser { get; set; }

        public string FollowedUserId { get; set; } = string.Empty;
        public User? FollowedUser { get; set; }

    }
}
