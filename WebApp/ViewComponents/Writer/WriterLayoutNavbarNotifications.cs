using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Writer
{
    public class WriterLayoutNavbarNotifications : ViewComponent
    {
        private INotificationService _notificationService;

        public WriterLayoutNavbarNotifications(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke(int userId)
        {
            var result = _notificationService.GetAllByUserId(userId);

            return View(result);
        }
    }
}
