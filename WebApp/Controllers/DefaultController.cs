using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class DefaultController : Controller
	{
		public PartialViewResult HeaderSearchPartial()
		{
			return PartialView();
		}

		public PartialViewResult FooterAboutUsPartial()
		{
			return PartialView();
		}

		public PartialViewResult FooterSignupNewsletterPartial()
		{
			return PartialView();
		}

		public PartialViewResult BlogReadAddCommentPartial()
		{
			return PartialView();
		}

		public PartialViewResult BlogReadRightSignupNewsletterPartial()
		{
			return PartialView();
		}
	}
}
