using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutTitle).NotEmpty().WithMessage(Messages.BlogTitleNotEmpty);
            RuleFor(x => x.AboutTitle).MinimumLength(5).WithMessage(Messages.BlogTitleMinimumLength);
            RuleFor(x => x.AboutTitle).MaximumLength(100).WithMessage(Messages.BlogTitleMaximumLength);
            RuleFor(x => x.AboutText).NotEmpty().WithMessage(Messages.BlogContentNotEmpty);
            RuleFor(x => x.AboutText).MinimumLength(100).WithMessage(Messages.BlogContentMinimumLength);
            RuleFor(x => x.AboutImageUrl).NotEmpty().WithMessage(Messages.BlogImageUrlNotEmpty);
            RuleFor(x => x.AboutThumbnailImageUrl).NotEmpty().WithMessage(Messages.BlogThumbnailImageUrlNotEmpty);
        }
    }
}
