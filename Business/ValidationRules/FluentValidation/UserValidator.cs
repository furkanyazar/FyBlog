using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserFirstName).NotEmpty().WithMessage(Messages.UserFirstNameNotEmpty);
            RuleFor(x => x.UserFirstName).MinimumLength(2).WithMessage(Messages.UserFirstNameMinimumLength);
            RuleFor(x => x.UserFirstName).MaximumLength(20).WithMessage(Messages.UserFirstNameMaximumLength);
            RuleFor(x => x.UserLastName).NotEmpty().WithMessage(Messages.UserLastNameNotEmpty);
            RuleFor(x => x.UserLastName).MinimumLength(2).WithMessage(Messages.UserLastNameMinimumLength);
            RuleFor(x => x.UserLastName).MaximumLength(20).WithMessage(Messages.UserLastNameMaximumLength);
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
            RuleFor(x => x.UserEmail).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty);
            RuleFor(x => x.UserPassword).MinimumLength(8).WithMessage(Messages.UserPasswordMinimumLength);
            RuleFor(x => x.UserPassword).MaximumLength(50).WithMessage(Messages.UserPasswordMaximumLength);
        }
    }
}
