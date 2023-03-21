using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogService.Models.DTOs
{
    public class UpdateGenreDTO
    {
        public int Id { get; set; }

        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Yalnızca Metin İfadeleri")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;
    }
}
