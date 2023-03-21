using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Models.DTOs
{
    public class CreateLikeDTO
    {
        public DateTime CreateDate = DateTime.Now;
        public Status Status = Status.Active;
    }
}
