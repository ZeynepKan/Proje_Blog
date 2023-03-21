using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.PostServices
{
    public interface IPostService
    {
        Task<List<GetPostVM>> GetPosts();
        Task<List<GetPostDetailsVM>> GetPostDetails(int id);
        Task Create(CreatePostDTO model);
        void Update(UpdatePostDTO model);
        Task Delete(int id);
        Task<UpdatePostDTO> GetById(int id);
        
        

    }

}
