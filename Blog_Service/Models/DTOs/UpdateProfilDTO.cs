using Blog_Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog_Service.Models.DTOs
{
    public class UpdateProfilDTO
    {
        public int Id { get; set; }


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
        [DataType(DataType.EmailAddress ,ErrorMessage ="Email formatında olmalıdır")]   
        public string Email { get; set; }   

        public string ImagePath { get; set; }   
       
        [FileExtensions]
        public IFormFile UpLoadPath { get; set; } 
        
        public DateTime UpdateDate { get; set; }
        public Status Status => Status.Modified;
    }
}
