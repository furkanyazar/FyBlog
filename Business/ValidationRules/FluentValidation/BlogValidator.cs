using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage(Messages.BlogTitleNotEmpty);
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage(Messages.BlogTitleMinimumLength);
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage(Messages.BlogTitleMaximumLength);
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage(Messages.BlogContentNotEmpty);
            RuleFor(x => x.BlogContent).MinimumLength(100).WithMessage(Messages.BlogContentMinimumLength);
            RuleFor(x => x.BlogImageUrl).NotEmpty().WithMessage(Messages.BlogImageUrlNotEmpty);
            RuleFor(x => x.BlogThumbnailImageUrl).NotEmpty().WithMessage(Messages.BlogThumbnailImageUrlNotEmpty);
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage(Messages.CategoryIdNotEmpty);
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage(Messages.CategoryIdGreaterThan);
        }
    }
}
