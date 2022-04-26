using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
    public class HomeProfile : ViewComponent
    {
        private IAdminService _adminService;

		public HomeProfile(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _adminService.GetByUserId(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));

			return View(result);
		}
	}
}
