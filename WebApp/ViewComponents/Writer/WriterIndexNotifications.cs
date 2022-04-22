using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Writer
{
    public class WriterIndexNotifications : ViewComponent
    {
        private INotificationService _notificationService;

        public WriterIndexNotifications(INotificationService notificationService)
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
