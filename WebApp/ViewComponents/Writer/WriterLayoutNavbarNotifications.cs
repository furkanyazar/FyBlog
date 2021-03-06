using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.ViewComponents.Writer
{
    public class WriterLayoutNavbarNotifications : ViewComponent
    {
        private INotificationService _notificationService;

        public WriterLayoutNavbarNotifications(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _notificationService.GetLatestsByCount().Take(3).ToList();

            return View(result);
        }
    }
}
