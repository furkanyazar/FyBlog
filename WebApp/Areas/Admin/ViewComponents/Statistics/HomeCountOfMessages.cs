using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
	public class HomeCountOfMessages : ViewComponent
	{
		private IContactService _contactService;

		public HomeCountOfMessages(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _contactService.GetAll().Count;

			return View(result);
		}
	}
}
