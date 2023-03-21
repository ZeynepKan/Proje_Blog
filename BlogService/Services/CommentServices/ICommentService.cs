using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.CommentServices
{
    public interface ICommentService
    {
        Task Create(CreateCommentDTO model);
        void Update(UpdateCommentDTO model);
        Task Delete(int id);
        Task<UpdateCommentDTO> GetById(int id);
        Task<List<GetCommentVM>> GetComments(int id);
        //Task<List<GetCommentVM>> GetComments(); //Kullanıcıya ait yorumlar gelebilir. (yoruma yorum yapılabilir) (yoruma like atılabilir)
    }
}
