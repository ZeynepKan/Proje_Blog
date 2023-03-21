using BlogService.Models.DTOs;
using BlogService.Services.AppUserServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebBlog.Controllers
{
    public class LogInController : Controller
    {
        private readonly IAppUserService _appUserService;

        public LogInController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.LogIn(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Blog");
                }
            }
            return View(model);
        }
    }
}
