﻿using ThreadCity2._0BackEnd.Data;
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

        ICollection<PostDto>? IPostService.GetAllPosts()
        {
            var posts = _context.Posts.ToList();
            var postDtos = posts.Select(p => p.ToPostDto()).ToList();

            return postDtos;
        }


    }
}
