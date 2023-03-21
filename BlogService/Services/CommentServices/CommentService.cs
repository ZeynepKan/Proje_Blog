using AutoMapper;
using Blog_Core.Enums;
using Blog_Core.Model;
using Blog_Core.Repositories;
using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly  IMapper _mapper;

        public CommentService (ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task Create(CreateCommentDTO model)
        {
            var comment = _mapper.Map<Comment>(model);
            await _commentRepository.CreateAsync(comment);
        }

        public async Task Delete(int id)
        {
            var comment = await _commentRepository.GetDefault(x => x.Id == id);
            comment.DeleteDate= DateTime.Now;
            comment.Status = Status.Passive;
            _commentRepository.Delete(comment); 
        }

        public async Task<UpdateCommentDTO> GetById(int id)
        {
            var comment = await _commentRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdateCommentDTO
                {
                    Id = id,
                    Text = x.Text
                },
                expression: x => x.Id == id && x.Status != Status.Passive);

              return comment;
        }

        public async Task<List<GetCommentVM>> GetComments(int id)
        {
            var comments = await _commentRepository.GetFilteredList(
                selector: x => new GetCommentVM
                {
                    Id = id,
                    Text = x.Text,
                    CreateDate=x.CreateDate,
                    UserName = x.AppUser.FullName,
                    UserImage = x.AppUser.ImagePath
                },
                expression: x => x.PostId == id && x.Status != Status.Passive,
                orderBy: x => x.OrderByDescending(x => x.CreateDate),
                include: x => x.Include(x => x.AppUser));
            return comments;
        }

        //public async Task<List<GetCommentVM>> GetComments()
        //{
        //    var comments = await _commentRepository.GetFilteredList(
        //         selector: x => new GetCommentVM
        //         {
        //             Id = x.Id,
        //             Text = x.Text,
        //             CreateDate= x.CreateDate,  
        //             UserName = x.AppUser.FullName,
        //             UserImage = x.AppUser.ImagePath
                     
        //         },
        //         expression: x => x.Status != Status.Passive,
        //         orderBy: x => x.OrderByDescending(x => x.CreateDate),
        //         include: x => x.Include(x => x.AppUser));

        //    return comments;
        //}

        public void Update(UpdateCommentDTO model)
        {
            var comment=_mapper.Map<Comment>(model);    
            _commentRepository.Update(comment); 
        }
    }
}
