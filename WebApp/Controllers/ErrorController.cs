using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }
    }
}
