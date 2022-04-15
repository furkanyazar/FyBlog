using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
	public class BlogController : Controller
	{
		private IBlogService _blogService;

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IActionResult Index()
		{
			var result = _blogService.GetAllWithCategoryAndWriter().ToList();

			return View(result);
		}

		public IActionResult Read(int id)
		{
			var result = _blogService.GetByIdWithCategoryAndWriter(id);

			return View(result);
		}
	}
}
