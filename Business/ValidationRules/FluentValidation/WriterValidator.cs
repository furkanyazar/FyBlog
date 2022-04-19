using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterAbout).MinimumLength(5).WithMessage(Messages.WriterAboutMinimumLength);
			RuleFor(x => x.WriterAbout).MaximumLength(500).WithMessage(Messages.WriterAboutMaximumLength);
			RuleFor(x => x.User.UserEmail).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
			RuleFor(x => x.User.UserEmail).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);
			RuleFor(x => x.User.UserFirstName).NotEmpty().WithMessage(Messages.UserFirstNameNotEmpty);
			RuleFor(x => x.User.UserFirstName).MinimumLength(2).WithMessage(Messages.UserFirstNameMinimumLength);
			RuleFor(x => x.User.UserFirstName).MaximumLength(20).WithMessage(Messages.UserFirstNameMaximumLength);
			RuleFor(x => x.User.UserLastName).NotEmpty().WithMessage(Messages.UserLastNameNotEmpty);
			RuleFor(x => x.User.UserLastName).MinimumLength(2).WithMessage(Messages.UserLastNameMinimumLength);
			RuleFor(x => x.User.UserLastName).MaximumLength(20).WithMessage(Messages.UserLastNameMaximumLength);
			RuleFor(x => x.User.UserPassword).NotEmpty().WithMessage(Messages.UserPasswordNotEmpty);
			RuleFor(x => x.User.UserPassword).MinimumLength(8).WithMessage(Messages.UserPasswordMinimumLength);
			RuleFor(x => x.User.UserPassword).MaximumLength(50).WithMessage(Messages.UserPasswordMaximumLength);
		}
	}
}
