using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogService.Models.DTOs
{
    public class LoginDTO
    {
        [Display(Name = "Kullanıcı Adı")]
        [RegularExpression(@"[a-zA-Z ]+$", ErrorMessage = "Yalnızca Metin İfadeleri")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
