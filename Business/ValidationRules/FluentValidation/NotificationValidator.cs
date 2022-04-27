using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.NotificationDetail).NotEmpty().WithMessage(Messages.NotificationDetailNotEmpty);
            RuleFor(x => x.NotificationDetail).MinimumLength(5).WithMessage(Messages.NotificationDetailMinimumLength);
            RuleFor(x => x.NotificationDetail).MaximumLength(50).WithMessage(Messages.NotificationDetailMaximumLength);
        }
    }
}
