using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsletterValidator : AbstractValidator<Newsletter>
    {
        public NewsletterValidator()
        {
            RuleFor(x => x.NewsletterEmail).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
            RuleFor(x => x.NewsletterEmail).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);
        }
    }
}
