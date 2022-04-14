using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        private ICommentService _commentService;

        public DefaultController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public PartialViewResult HeaderSearchPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterAboutUsPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterLatestBlogsPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterSignupNewsletterPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadAddCommentPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightSignupNewsletterPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightSimilarBlogsPartial()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadRightLatestPartial()
        {
            return PartialView();
        }
    }
}
