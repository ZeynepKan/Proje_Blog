using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog_Service.Models.DTOs
{
    public class LoginDTO
    {
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Yalnızca Metin İfadeleri")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Boş Geçilemez")]
        [MinLength(3,ErrorMessage ="Min 3 karakter")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }    
    }
}
