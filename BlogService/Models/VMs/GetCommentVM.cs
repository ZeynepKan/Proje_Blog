using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Models.VMs
{
   public class GetCommentVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
