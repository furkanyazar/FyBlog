using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Layout
{
    public class AdminLayoutNavbarCountOfNotifications : ViewComponent
    {
        private INotificationService _notificationService;

        public AdminLayoutNavbarCountOfNotifications(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _notificationService.GetLatestsByCount().Count;

            return View(result);
        }
    }
}
