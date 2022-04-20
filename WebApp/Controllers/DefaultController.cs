using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private INewsletterService _newsletterService;
        private ICommentService _commentService;

        private NewsletterValidator newsletterValidator = new NewsletterValidator();
        private CommentValidator commentValidator = new CommentValidator();
        private ValidationResult validation;

        public DefaultController(INewsletterService newsletterService, ICommentService commentService)
        {
            _newsletterService = newsletterService;
            _commentService = commentService;
        }

        public PartialViewResult HeaderSearchPartial()
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

        public IActionResult SignupNewsletter(Newsletter newsletter)
        {
            validation = newsletterValidator.Validate(newsletter);

            if (validation.IsValid)
            {
                _newsletterService.Add(newsletter);

                return Json(new { success = true, message = "E-posta bültenine başarıyla kayıt oldunuz" });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult Comment(Comment comment)
        {
            validation = commentValidator.Validate(comment);

            if (validation.IsValid)
            {
                _commentService.Add(comment);

                return Json(new { success = true });
            }

            return Json(new { success = false, message = validation.Errors[0].ErrorMessage });
        }

        public IActionResult DeleteComment(int commentId, int blogId)
        {
            var result = _commentService.GetByCommentId(commentId);
            result.CommentStatus = false;

            _commentService.Update(result);

            return RedirectToAction("Read", "Blog", new { blogId = blogId }, "comments");
        }
    }
}
