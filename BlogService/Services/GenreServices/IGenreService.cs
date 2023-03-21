using Blog_Core.Model;
using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.GenreServices
{
    public interface IGenreService
    {
        Task Create(CreateGenreDTO model);
        void Update(UpdateGenreDTO model);
        Task Delete(int id);
        Task<UpdateGenreDTO> GetById(int id);
        Task<List<GetGenreVM>> GetGenres();
      
    }
}
