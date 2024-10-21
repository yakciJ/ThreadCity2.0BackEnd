using ThreadCity2._0BackEnd.Data;
using ThreadCity2._0BackEnd.Models.DTO;
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


        ICollection<PostDto>? IPostService.GetAllPosts()
        {
            var posts = _context.Posts.ToList();
            var postDtos = posts.Select(p => p.ToPostDto()).ToList();

            return postDtos;
        }


    }
}
