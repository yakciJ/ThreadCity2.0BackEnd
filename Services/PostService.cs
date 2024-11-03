using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            var postDtos = await (from post in _context.Posts
                                  join postScore in _context.PostScores on post.PostId equals postScore.PostId into ps
                                  from postScore in ps.DefaultIfEmpty()
                                  join userPostScore in _context.UserPostScores.Where(x => x.UserId == user.Id) on post.PostId equals userPostScore.PostId into ups
                                  from userPostScore in ups.DefaultIfEmpty()
                                  let timeScore = postScore != null ? postScore.TimeScore : 0.0
                                  let popularityScore = postScore != null ? postScore.PopularityScore : 0.0
                                  let relevanceScore = userPostScore != null ? userPostScore.RelevanceScore : 0.0
                                  let rankingScore = (timeScore * 0.6) +
                                                    (popularityScore * 0.2) +
                                                    (relevanceScore * 0.2)
                                  orderby rankingScore descending
                                  select new PostDto
                                  {
                                      UserId = post.UserId,
                                      Title = post.Title,
                                      Content = post.Content,
                                      CreatedAt = post.CreatedAt,
                                      AuthorUserName = post.User!.UserName,
                                      AuthorFullName = post.User!.FullName
                                  })
               .Skip(skipNumber)
               .Take(postQuery.PageSize)
               .ToListAsync();


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

        public async Task<IActionResult> UpdateUserPostScoresAsync(string userId)
        {
            Dictionary<int, int> updatedRelevanceScore = new Dictionary<int, int>();
            int likeScore = 1;
            int commentScore = 2;
            int userPostScore = 3;

            var user = await _context.Users
                .Include(u => u.Following!)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string json = JsonConvert.SerializeObject(user, settings);
            Console.WriteLine(json);

            if (user == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            try
            {
                if (user.Following != null)
                {
                    foreach (var follow in user.Following)
                    {
                        var userLikePosts = await _context.Users
                            .Select(u => new
                            {
                                u.Id,
                                u.LikePosts
                            })
                            .FirstOrDefaultAsync(u => u.Id == follow.FollowedUserId);
                        var likePosts = userLikePosts?.LikePosts;

                        if (likePosts == null)
                            continue;
                        foreach (var likePost in likePosts)
                        {
                            int postId = likePost.PostId;
                            IncreaseScores(updatedRelevanceScore, postId, likeScore);
                        }


                        var userComments = await _context.Users
                            .Select(u => new
                            {
                                u.Id,
                                u.Comments
                            })
                            .FirstOrDefaultAsync(u => u.Id == follow.FollowedUserId);
                        var comments = userComments?.Comments;

                        if (comments == null)
                            continue;
                        foreach (var cmt in comments)
                        {
                            List<int> consideredPostIds = new List<int>();
                            int postId = cmt.PostId;
                            if (consideredPostIds.Contains(postId))
                                continue;
                            IncreaseScores(updatedRelevanceScore, postId, commentScore);
                            consideredPostIds.Add(postId);
                        }


                        var userPosts = await _context.Users
                            .Select(u => new
                            {
                                u.Id,
                                u.Posts
                            })
                            .FirstOrDefaultAsync(u => u.Id == follow.FollowedUserId);
                        var posts = userPosts?.Posts;

                        if (posts == null)
                            continue;
                        foreach (var post in posts)
                        {
                            var postId = post.PostId;
                            IncreaseScores(updatedRelevanceScore, postId, userPostScore);
                        }
                    }
                }

                if (updatedRelevanceScore.Count == 0)
                    return new OkObjectResult("No updates");

                double max = updatedRelevanceScore.Values.Max();
                double min = updatedRelevanceScore.Values.Min();

                foreach (var score in updatedRelevanceScore)
                {
                    int postId = score.Key;
                    double normalizeScore = Normalize(score.Value, max, min);
                    var existedScore = await _context.UserPostScores.FirstOrDefaultAsync(u => u.UserId == user.Id && u.PostId == postId);
                    if (existedScore == null)
                    {
                        var newScore = new UserPostScore
                        {
                            UserId = user.Id,
                            PostId = postId,
                            RelevanceScore = normalizeScore
                        };
                        await _context.UserPostScores.AddAsync(newScore);
                    }
                    else
                    {
                        existedScore.RelevanceScore = normalizeScore;
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

        private static void IncreaseScores(Dictionary<int, int> scoresDict, int id, int scoreToIncrease)
        {
            if (scoresDict.TryGetValue(id, out int score))
            {
                scoresDict[id] += scoreToIncrease;
            }
            else
            {
                scoresDict.Add(id, scoreToIncrease);
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
