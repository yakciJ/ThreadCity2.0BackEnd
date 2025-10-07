using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThreadCity2._0BackEnd.Extensions;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostScore> PostScores { get; set; }
        public DbSet<UserPostScore> UserPostScores { get; set; }
        public DbSet<LikePost> LikePosts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<SeenPost> SeenPosts { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<LinkPostTag> LinkPostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Follow>()
                .HasKey(lp => new { lp.FollowerUserId, lp.FollowedUserId });

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.FollowerUser)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.FollowedUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowedUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikePost>()
                .HasKey(lp => new { lp.UserId, lp.PostId });

            modelBuilder.Entity<LikePost>()
                .HasOne(lp => lp.User)
                .WithMany(u => u.LikePosts)
                .HasForeignKey(lp => lp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikePost>()
                .HasOne(lp => lp.Post)
                .WithMany(p => p.LikePosts)
                .HasForeignKey(lp => lp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeenPost>()
                .HasOne(sp => sp.User)
                .WithMany(u => u.SeenPosts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeenPost>()
                .HasOne(sp => sp.Post)
                .WithMany(p => p.SeenPosts)
                .HasForeignKey(sp => sp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Share>()
                .HasOne(s => s.User)
                .WithMany(u => u.Shares)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Share>()
                .HasOne(s => s.Post)
                .WithMany(p => p.Shares)
                .HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikeComment>()
                .HasKey(lp => new { lp.UserId, lp.CommentId });

            modelBuilder.Entity<LikeComment>()
                .HasOne(lc => lc.User)
                .WithMany(u => u.LikeComments)
                .HasForeignKey(lc => lc.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Changed from Cascade to NoAction

            modelBuilder.Entity<LikeComment>()
                .HasOne(lc => lc.Comment)
                .WithMany(c => c.LikeComments)
                .HasForeignKey(lc => lc.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPostScore>()
                .HasKey(ups => new { ups.UserId, ups.PostId });

            modelBuilder.Entity<UserPostScore>()
                .HasOne(ups => ups.User)
                .WithMany(u => u.UserPostScores)
                .HasForeignKey(ups => ups.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserPostScore>()
                .HasOne(ups => ups.Post)
                .WithMany(u => u.UserPostScores)
                .HasForeignKey(ups => ups.PostId)
                .OnDelete(DeleteBehavior.Cascade);


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            string providerName = Database.ProviderName ?? "";
            modelBuilder.UseUtcDateTimeWithProviderAdjustment(providerName);
        }
    }
}
