using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Core.Model
{
    public class Comment:IBaseEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
