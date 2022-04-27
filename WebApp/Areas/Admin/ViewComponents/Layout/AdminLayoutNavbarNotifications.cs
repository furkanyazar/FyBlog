using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Layout
{
    public class AdminLayoutNavbarNotifications : ViewComponent
    {
        private INotificationService _notificationService;

        public AdminLayoutNavbarNotifications(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _notificationService.GetLatestsByCount();

            return View(result);
        }
    }
}
