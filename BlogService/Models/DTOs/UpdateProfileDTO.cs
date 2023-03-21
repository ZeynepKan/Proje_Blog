using Blog_Core.Enums;
using BlogService.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogService.Models.DTOs
{
    public class UpdateProfileDTO
    {
        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 Karakter")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email formatında olmalıdır.")]
        public string Email { get; set; }
        public string ImagePath { get; set; }

        [FileExtension]
        public IFormFile UploadPath { get; set; }
        public Status Status => Status.Modified;
        public DateTime UpdateDate => DateTime.Now;
    }
}
