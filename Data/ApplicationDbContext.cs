using Microsoft.EntityFrameworkCore;
using ThreadCity2._0BackEnd.Models.Entities;

namespace ThreadCity2._0BackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
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
                .HasOne(f => f.FollowerUser)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follow>()
                .HasOne(f => f.FollowedUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LikePost>()
                .HasOne(lp => lp.User)
                .WithMany(u => u.LikePosts)
                .HasForeignKey(lp => lp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LikePost>()
                .HasOne(lp => lp.Post)
                .WithMany(p => p.LikePosts)
                .HasForeignKey(lp => lp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeenPost>()
                .HasOne(sp => sp.User)
                .WithMany(u => u.SeenPosts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SeenPost>()
                .HasOne(sp => sp.Post)
                .WithMany(p => p.SeenPosts)
                .HasForeignKey(sp => sp.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Share>()
                .HasOne(s => s.User)
                .WithMany(u => u.Shares)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Share>()
                .HasOne(s => s.Post)
                .WithMany(p => p.Shares)
                .HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LikeComment>()
                .HasOne(lc => lc.User)
                .WithMany(u => u.LikeComments)
                .HasForeignKey(lc => lc.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Changed from Cascade to NoAction

            modelBuilder.Entity<LikeComment>()
                .HasOne(lc => lc.Comment)
                .WithMany(c => c.LikeComments)
                .HasForeignKey(lc => lc.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
