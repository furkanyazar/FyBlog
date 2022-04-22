using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Writer
{
    public class WriterLayoutNavbarCountOfNotifications : ViewComponent
    {
        private INotificationService _notificationService;

        public WriterLayoutNavbarCountOfNotifications(INotificationService notificationService)
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
