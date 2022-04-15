using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }
    }
}
