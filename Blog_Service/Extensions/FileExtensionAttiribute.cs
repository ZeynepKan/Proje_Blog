using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Blog_Service.Extensions
{
    public class FileExtensionAttiribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           IFormFile file =value as IFormFile;
            if (file != null)

            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { "jpg", "jpeg", "png" };
                bool result = extensions.Any(x=>extension.EndsWith(x));
                if (!result)
                {
                    return new ValidationResult(GetErrorMessage());

                }
            }
                return ValidationResult.Success;    
            }
        private string GetErrorMessage() => "Yalnızca JPG,JPEG ve PNG";
        }

    }
}
