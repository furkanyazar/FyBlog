using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Admin
{
    public class AdminLayoutSidebarProfile : ViewComponent
    {
        private IAdminService _adminService;

        public AdminLayoutSidebarProfile(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IViewComponentResult Invoke(int userId)
        {
            var result = _adminService.GetByUserId(userId);

            return View(result);
        }
    }
}
