using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThreadCity2._0BackEnd.Data;
using ThreadCity2._0BackEnd.Helpers;
using ThreadCity2._0BackEnd.Models.DTO.Post;
using ThreadCity2._0BackEnd.Models.Entities;
using ThreadCity2._0BackEnd.Models.Mappers;
using ThreadCity2._0BackEnd.Services.Interfaces;

namespace ThreadCity2._0BackEnd.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostDto> CreatePostAsync(string userId, CreatePostRequestDto requestDto)
        {
            var post = requestDto.ToPostFromCreate();
            post.UserId = userId;
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post.ToPostDto();
        }

        public async Task<ICollection<PostDto>?> GetAllPostsAsync()
        {
            var posts = await _context.Posts.Include(p => p.User).ToListAsync();
            var postDtos = posts.Select(p => p.ToPostDto()).ToList();

            return postDtos;
        }

        public async Task<ICollection<PostDto>?> GetUserNewsfeedAsync(User user, PostQuery postQuery)
        {
            int skipNumber = (postQuery.PageNumber - 1) * postQuery.PageSize;

            var posts = await _context.Posts
                .Include(p => p.User)
                .AsQueryable()
                .OrderByDescending(p => p.PostScore != null ? p.PostScore.TimeScore * 0.6f + p.PostScore.PopularityScore * 0.2f : 0)
                .Skip(skipNumber)
                .Take(postQuery.PageSize)
                .ToListAsync();
            var postDtos = posts.Select(p => p.ToPostDto()).ToList();

            return postDtos;
        }

        public async Task<IActionResult> UpdatePostScoresAsync()
        {
            try
            {
                var posts = await _context.Posts
                    .Include(p => p.PostScore)
                    .Include(p => p.LikePosts)
                    .Include(p => p.Comments)
                    .ToListAsync();

                double maxTimeScore = posts.Max(p => CalculatePostTimeScore(p)); 
                double minTimeScore = posts.Min(p => CalculatePostTimeScore(p));

                double maxPopularityScore = posts.Max(p => CalculatePostPopularityScore(p));
                double minPopularityScore = posts.Min(p => CalculatePostPopularityScore(p));

                foreach (var post in posts)
                {
                    double rawTimeScore = CalculatePostTimeScore(post); 
                    double timeScore = Normalize(rawTimeScore, maxTimeScore, minTimeScore);

                    double rawPopularityScore = CalculatePostPopularityScore(post);
                    double popularityScore = Normalize(rawPopularityScore, maxPopularityScore, minPopularityScore);

                    if (post.PostScore == null)
                    {
                        var postScore = new PostScore
                        {
                            PostId = post.PostId,
                            TimeScore = timeScore,
                            PopularityScore = popularityScore
                        };
                        await _context.PostScores.AddAsync(postScore);
                    }
                    else
                    {
                        post.PostScore.TimeScore = timeScore;
                        post.PostScore.PopularityScore = popularityScore;
                    }
                }
                await _context.SaveChangesAsync();
                return new OkObjectResult("Update completed");

            }
            catch (Exception e)
            {
                return new ObjectResult(e) { StatusCode = 500 };
            }
        }

        private double CalculatePostTimeScore(Post post)
        {
            return 1.0f / (DateTime.Now - post.CreatedAt).TotalSeconds;

        }

        private double CalculatePostPopularityScore(Post post)
        {
            var likeCount = post.LikePosts != null ? post.LikePosts.Count : 0;
            var commentCount = post.Comments != null ? post.Comments.Count : 0;
            return likeCount * 1.0f + commentCount * 2.0f;
        }

        private double Normalize(double raw, double max, double min)
        {
            if (max == min)
            {
                return 0;
            }
            return (raw - min) / (max - min);
        }
    }
}
