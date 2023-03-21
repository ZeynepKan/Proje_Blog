using BlogService.Services.CommentServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebBlog.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{
		private readonly ICommentService _commentService;
		public CommentListByBlog(ICommentService commentService)
		{
			_commentService = commentService;
		}

        
		public async Task<IViewComponentResult> InvokeAsync(int id)
   		{
            var comments =await _commentService.GetComments(id);
            return View (comments);	
		}

       
	}
}
