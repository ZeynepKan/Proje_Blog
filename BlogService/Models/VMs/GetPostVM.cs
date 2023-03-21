﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Models.VMs
{
    public class GetPostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
		public string PostImage { get; set; }
		public string GenreName { get; set; }
		public DateTime CreateDate { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorImage { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
