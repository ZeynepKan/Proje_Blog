using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Service.Models.VMs
{
    public class GenrePostVM
    {
       public int ID { get; set; }    
        public string Title { get; set; }   
        public string Content { get; set; } 
        public DateTime CreateDate { get; set; }
        public string AuthorFullName { get; set; }  
        public string AuthorImage { get; set; }
        public int LikeCount { get; set; }  
        public int CommentCount { get; set; }   

    }
}
