using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Writer
{
    public class WriterLayoutNavbarNotifications : ViewComponent
    {
        public IViewComponentResult Invoke(int userId)
        {
            return View();
        }
    }
}
