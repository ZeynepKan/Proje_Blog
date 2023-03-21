using BlogService.Models.DTOs;
using BlogService.Models.VMs;
using BlogService.Services.PostServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebBlog.Controllers
{
	public class BlogController : Controller
	{
		private readonly IPostService _postService;
		public BlogController(IPostService postService)
		{
			_postService= postService;
		}
			
			public async Task<IActionResult> Index ()
			{
				
			var posts = await _postService.GetPosts();

			return View(posts);
		
		}
		public async Task<IActionResult> BlogReadAll (int id)
		{
			ViewBag.i= id;	
			var posts =await _postService.GetPostDetails(id);	
			return View(posts);	
		}

		
	}
}
