using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogService.Models.DTOs
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string Title { get; set; }
        public string Content { get; set; }
		public string PostImage { get; set; }
		public string GenreName { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
