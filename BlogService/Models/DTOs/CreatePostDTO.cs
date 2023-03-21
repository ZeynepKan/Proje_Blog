using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Models.DTOs
{
   public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PostImage { get; set; }   
        public string GenreName { get; set; }   
        public DateTime CreateDate= DateTime.Now;
        public Status Status = Status.Active;
    }
}
