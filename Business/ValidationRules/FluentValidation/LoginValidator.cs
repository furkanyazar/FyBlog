﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<User>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
            RuleFor(x => x.UserEmail).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty);
            RuleFor(x => x.UserPassword).MinimumLength(8).WithMessage(Messages.UserPasswordMinimumLength);
            RuleFor(x => x.UserPassword).MaximumLength(50).WithMessage(Messages.UserPasswordMaximumLength);
        }
    }
}
