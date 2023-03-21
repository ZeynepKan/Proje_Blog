using Blog_Core.Repositories;
using BlogService.Services.GenreServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebBlog.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		private readonly IGenreService _genreService;
		public CategoryList (IGenreService genreService)
		{
        _genreService= genreService;	
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var genres = await _genreService.GetGenres();
			return View (genres);

		}
	}
} 
