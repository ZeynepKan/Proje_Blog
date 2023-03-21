using AutoMapper;
using Blog_Core.Enums;
using Blog_Core.Model;
using Blog_Core.Repositories;
using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.LikeServices
{
    public class LikeService : ILikeService
    {

        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LikeService ( ILikeRepository likeRepository, IMapper mapper )
        {
            _likeRepository = likeRepository;
            _mapper = mapper;   
        }
    
        public async Task Create(CreateLikeDTO model)
        {
            var like = _mapper.Map<Like>(model);
            await _likeRepository.CreateAsync(like);

        }

        public async Task Delete(int id)
        {
           var like= await _likeRepository.GetDefault(x=>x.Id==id);    
            like.DeleteDate = DateTime.Now;
            like.Status = Status.Passive;
            _likeRepository.Delete(like);


        }

        public async Task<List<GetLikeVM>> GetLikes()
        {
            var likes = await _likeRepository.GetFilteredList(
                selector: x => new GetLikeVM
                {

                    ID = x.Id,
                    UserName = x.AppUser.FullName,
                    CreateDate= x.CreateDate
                  
                },
                expression: x => x.Status != Status.Passive,
                orderBy: x => x.OrderBy(x => x.CreateDate)); ;

            return likes;

               
        }
    }

}
   
