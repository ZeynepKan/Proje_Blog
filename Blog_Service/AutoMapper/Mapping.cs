using AutoMapper;
using Blog_Core.Model;
using Blog_Service.Models.DTOs;
using Blog_Service.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Service.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping() { 
            
            CreateMap<Genre, CreateGenreDTO>().ReverseMap();
            CreateMap<Genre, UpdateGenreDTO>().ReverseMap();    
            CreateMap<Genre,GetGenreVM>().ReverseMap();

            CreateMap<AppUser,RegisterDTO>().ReverseMap();  
            CreateMap<AppUser,LoginDTO>().ReverseMap();
            CreateMap<AppUser,UpdateProfilDTO>().ReverseMap();  
            CreateMap<Comment,GetCommentVM>().ReverseMap();
        
        
        }    
      
        
    }
}
