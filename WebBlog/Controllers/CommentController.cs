using BlogService.Services.CommentServices;
using BlogService.Services.PostServices;
using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PartialAddComment()
		{
			return PartialView();	
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var comments =_commentService.GetComments(id);	
			return PartialView(comments);	
		}
	}
}
