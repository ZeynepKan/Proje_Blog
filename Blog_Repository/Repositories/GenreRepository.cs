using Blog_Core.Model;
using Blog_Core.Repositories;
using Blog_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repository.Repositories

{
    public class GenreRepository:BaseRepository<Genre>,IGenreRepository         
    {
        public GenreRepository (AppDbContext appDbContext) : base(appDbContext) { } 
    }
}
