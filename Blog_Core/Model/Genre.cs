﻿using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Core.Model
{
   public class Genre:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }

        public List<Post> Posts { get; set; }
    }
}
