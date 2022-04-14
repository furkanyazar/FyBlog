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

        public PartialViewResult HeaderSearchPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterLeftPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterCenterPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterRightPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadCommentsPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadAddCommentPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightFirstPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightSecondPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightThirdPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightFourthPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightFifthPartial()
        {
            return PartialView();
        }
    }
}
