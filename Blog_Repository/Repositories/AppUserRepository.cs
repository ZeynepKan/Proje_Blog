using Blog_Core.Model;
using Blog_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repository.Repositories
{
    public class AppUserRepository:BaseRepository<AppUser>,IAppUserRepository
    {
        public AppUserRepository (AppDbContext appDbContext) : base(appDbContext) 
        {
        }
    }
}
