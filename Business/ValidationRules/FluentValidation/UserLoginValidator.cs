using Business.Constants;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
            RuleFor(x => x.UserEmail).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty);
            RuleFor(x => x.UserPassword).MinimumLength(8).WithMessage(Messages.UserPasswordMinimumLength);
            RuleFor(x => x.UserPassword).MaximumLength(50).WithMessage(Messages.UserPasswordMaximumLength);
        }
    }
}
