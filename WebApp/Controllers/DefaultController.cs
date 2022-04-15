using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {
        private INewsletterService _newsletterService;

        private NewsletterValidator _newsletterValidator = new NewsletterValidator();
        private ValidationResult _validation;

        public DefaultController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public PartialViewResult HeaderSearchPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterAboutUsPartial()
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
            _validation = _newsletterValidator.Validate(newsletter);

            if (_validation.IsValid)
            {
                _newsletterService.Add(newsletter);

                return Json(new { success = true, message = "E-posta bültenine başarıyla kayıt oldunuz" });
            }

            return Json(new { success = false, message = _validation.Errors[0].ErrorMessage });
        }
    }
}
