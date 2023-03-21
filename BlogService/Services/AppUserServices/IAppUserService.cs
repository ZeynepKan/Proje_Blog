using BlogService.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogService.Services.AppUserServices
{
     public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> LogIn(LoginDTO model);
        Task LogOut();
        Task<UpdateProfileDTO> GetById(string id);
        Task UpdateUser(UpdateProfileDTO model);
    }
}
