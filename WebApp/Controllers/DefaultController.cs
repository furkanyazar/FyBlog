using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        private IBlogService _blogService;

        public DefaultController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
    }
}
