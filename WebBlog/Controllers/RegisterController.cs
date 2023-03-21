using BlogService.Models.DTOs;
using BlogService.Services.AppUserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebBlog.Controllers
{
    public class RegisterController : Controller
    {


        private readonly IAppUserService _appUserService;

        public RegisterController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Blog");
                }
            }
            return View(model);
        }
        //[HttpGet]
        //public IActionResult LogIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> LogIn(LoginDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _appUserService.LogIn(model);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Blog");
        //        }
        //    }
        //    return View(model);
        //}

        //public async Task<IActionResult> LogOut()
        //{
        //    await _appUserService.LogOut();
        //    return RedirectToAction("Index", "Blog");
        //}
    }
}
       

