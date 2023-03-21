using AutoMapper;
using Blog_Core.Enums;
using Blog_Core.Model;
using Blog_Core.Repositories;
using Blog_Repository.Repositories;
using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPostDetailsVM>> GetPostDetails(int id)
        {
            var post = await _postRepository.GetFilteredList(
                selector: x => new GetPostDetailsVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    GenreName=x.Genre.Name,
                    PostImage=x.PostImage,
					CreateDate = x.CreateDate,
					AuthorFullName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.ImagePath,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count,
                    Comments = x.Comments.Where(x => x.PostId == id)
                                            .OrderByDescending(x => x.CreateDate)
                                            .Select(x => new GetCommentVM
                                            {
                                                Id = x.Id,
                                                Text = x.Text,
                                                CreateDate = x.CreateDate,
                                                UserName = x.AppUser.UserName,
                                                UserImage = x.AppUser.ImagePath,
                                            }).ToList()
                },
                expression: x => x.Id == id && x.Status != Status.Passive,
                include: x => x.Include(x => x.AppUser).ThenInclude(x => x.Comments));

            return post;
        }

        public async Task<List<GetPostVM>> GetPosts()
        {
            var posts = await _postRepository.GetFilteredList(
                selector: x => new GetPostVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
					GenreName = x.Genre.Name,
					PostImage = x.PostImage,
                    CreateDate=x.CreateDate,
					AuthorFullName = x.AppUser.FullName,
                    AuthorImage = x.AppUser.ImagePath,
                    LikeCount = x.Likes.Count,
                    CommentCount = x.Comments.Count,
                },
                expression: x => x.Status != Status.Passive,
            orderBy:x=>x.OrderByDescending(x => x.CreateDate),    
                include: x => x.Include(x => x.AppUser));

            return posts;
        }
        public async Task Create(CreatePostDTO model)
        {
            var post = _mapper.Map<Post>(model);
            await _postRepository.CreateAsync(post);
        }

        public async Task Delete(int id)
        {
            var post= await _postRepository.GetDefault(x => x.Id == id);
            post.DeleteDate = DateTime.Now;
            post.Status = Status.Passive;
            _postRepository.Delete(post);
        }

        public async Task<UpdatePostDTO> GetById(int id)
        {
            var post = await _postRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdatePostDTO
                {
                    Id = id,
                    Title= x.Title, 
                   Content= x.Content,  
                  
                },
                expression: x => x.Id == id && x.Status != Status.Passive);

            return post;
        }

       
        public void Update(UpdatePostDTO model)
        {
            var post = _mapper.Map<Post>(model);
            _postRepository.Update(post);
        }
    }
}
