using AutoMapper;
using Blog_Core.Model;
using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Genre, CreateGenreDTO>().ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap();
            CreateMap<Genre, GetGenreVM>().ReverseMap();

            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDTO>().ReverseMap();


            CreateMap<Post, CreatePostDTO>().ReverseMap();
            CreateMap<Post, UpdatePostDTO>().ReverseMap();
            CreateMap<Post,GetPostVM>().ReverseMap();  
            CreateMap<Post,GetPostDetailsVM>().ReverseMap();
                      
            CreateMap<Comment, CreateCommentDTO>().ReverseMap();
            CreateMap<Comment, UpdateCommentDTO>().ReverseMap(); 
            CreateMap<Comment,GetCommentVM>().ReverseMap();

            CreateMap<Like, CreateLikeDTO>().ReverseMap();  
         
            CreateMap<Like, GetLikeVM>().ReverseMap();  
        }
    }
}
