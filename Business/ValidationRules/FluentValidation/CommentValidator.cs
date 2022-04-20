using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentContent).NotEmpty().WithMessage(Messages.CommentContentNotEmpty);
            RuleFor(x => x.CommentContent).MinimumLength(5).WithMessage(Messages.CommentContentMinimumLength);
            RuleFor(x => x.CommentContent).MaximumLength(500).WithMessage(Messages.CommentContentMaximumLength);
        }
    }
}
