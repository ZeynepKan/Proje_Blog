using AutoMapper;
using Blog_Core.Enums;
using Blog_Core.Model;
using Blog_Core.Repositories;
using Blog_Repository.Configurations;
using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateGenreDTO model)
        {
            var genre = _mapper.Map<Genre>(model);

            await _genreRepository.CreateAsync(genre);
        }

        public async Task Delete(int id)
        {
            var genre = await _genreRepository.GetDefault(x => x.Id == id);

            genre.DeleteDate = DateTime.Now;
            genre.Status = Status.Passive;

            _genreRepository.Delete(genre);
        }

        public async Task<UpdateGenreDTO> GetById(int id)
        {
            var genre = await _genreRepository.GetFilteredFirstOrDefault(selector: x => new UpdateGenreDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            },
            expression: x => x.Id == id && x.Status != Status.Passive);

            return genre;
        }



        public async Task<List<GetGenreVM>> GetGenres()
        {
            var genres = await _genreRepository.GetFilteredList(selector: x => new GetGenreVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            },
            expression: x => x.Status != Status.Passive,
            orderBy:x=>x.OrderBy(x=>x.Name));

            return genres;
        }

        public void Update(UpdateGenreDTO model)
        {
            var genre = _mapper.Map<Genre>(model);
            _genreRepository.Update(genre);

        }

    
    }
}
