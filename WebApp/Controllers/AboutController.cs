using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var result = _aboutService.GetAll().LastOrDefault();

            return View(result);
        }
    }
}
