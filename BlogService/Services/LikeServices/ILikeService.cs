using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.LikeServices
{
   public interface ILikeService
    {
        Task Create(CreateLikeDTO model);
        Task Delete(int id);
        Task<List<GetLikeVM>> GetLikes ();

    }
}
