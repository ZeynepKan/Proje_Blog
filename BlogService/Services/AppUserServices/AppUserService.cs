using AutoMapper;
using Blog_Core.Enums;
using Blog_Core.Model;
using Blog_Core.Repositories;
using BlogService.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BlogService.Services.AppUserServices
{
    public class AppUserService : IAppUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAppUserRepository appUserRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }
    
        public async Task<UpdateProfileDTO> GetById(string id)
        {
            var user = await _appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new UpdateProfileDTO
                {
                    Id = id,
                    FullName = x.FullName,
                    UserName = x.UserName,
                    Email = x.Email,
                },
                expression: x => x.Id == id && x.Status !=Status.Passive);
            return user;    
        }

        public async Task<SignInResult> LogIn(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;  
        }

        public async Task LogOut()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            var user = _mapper.Map<AppUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            var user = await _appUserRepository.GetDefault(x=> x.Id == model.Id);   
            if (user!=null)
            {
                if (model.UploadPath != null)
                {
                    using var image = Image.Load(model.UploadPath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    var guid = Guid.NewGuid();
                    image.Save($"www.roote/images/users/{guid}.jpg");
                    user.ImagePath = $"www.roote/images/users/{guid}.jpg";
                    _appUserRepository.Update(user);
                }
                if (model.FullName!= null) 
                { 
                user.FullName = model.FullName;
                    _appUserRepository.Update(user);    
                }
                if(model.Password!=null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword
                        (user, model.Password);
                    await _userManager.UpdateAsync(user);   

                }
                if (model.Email!= null)
                {
                    await _userManager.SetUserNameAsync(user, model.UserName);
                    await _signInManager.SignInAsync(user, false);  
                }
                
            }
        }
    }
}
