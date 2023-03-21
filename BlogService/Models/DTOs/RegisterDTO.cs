using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogService.Models.DTOs
{
    public class RegisterDTO
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string FullName { get; set; }

        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string UserName { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Şifre Tekrar")]
        [DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage ="Şifreler uyşmuyor")]
        public string ConfirmPassword { get; set; }

        public DateTime CreateDate => DateTime.Now;

        public Status Status = Status.Active;
    }
}
