using Microsoft.AspNetCore.Mvc;

namespace WebBlog.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{ 
			return View(); 
		}	
	}
}
