using Blog_Core.Model;
using Blog_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repository.Repositories
{
    public class CommentRepository:BaseRepository<Comment>,ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext):base(appDbContext)
        {
        }
    }
}
