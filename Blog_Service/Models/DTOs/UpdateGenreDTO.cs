using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog_Service.Models.DTOs
{
    public class UpdateGenreDTO
    {
     public int Id { get; set; }

        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Yalnızca Metin İfadeleri")]
        [Required(ErrorMessage ="Boş geçilemez")]
        [MinLength(3,ErrorMessage="Min 3 karakter")]
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime UpdateDate => DateTime.Now;
        public Status Status => Status.Modified;

    }
}
