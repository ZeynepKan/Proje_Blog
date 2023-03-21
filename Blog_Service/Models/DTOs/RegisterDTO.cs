using Blog_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog_Service.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage="Boş geçilemez")]
        [MinLength(3,ErrorMessage ="Minimum 3 kararker")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 kararker")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Boş geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 kararker")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Boş geçilemez")]
        [MinLength(3, ErrorMessage = "Minimum 3 kararker")]
        public string ConfirmPasword { get; set; }

        public DateTime CreateDate=> DateTime.Now;
        public Status Status => Status.Active;
    }
}
