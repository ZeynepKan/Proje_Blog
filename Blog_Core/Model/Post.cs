using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Core.Model
{
    public class Post:IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PostImage { get; set; }   
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }



    }
}
