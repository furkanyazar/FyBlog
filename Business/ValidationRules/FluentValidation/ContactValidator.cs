using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class ContactValidator : AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.ContactUserFullName).NotEmpty().WithMessage(Messages.UserFirstNameNotEmpty);
			RuleFor(x => x.ContactUserFullName).MinimumLength(2).WithMessage(Messages.UserFirstNameMinimumLength);
			RuleFor(x => x.ContactUserFullName).MaximumLength(20).WithMessage(Messages.UserFirstNameMaximumLength);
			RuleFor(x => x.ContactEmail).NotEmpty().WithMessage(Messages.UserEmailNotEmpty);
			RuleFor(x => x.ContactEmail).EmailAddress().WithMessage(Messages.UserEmailEmailAddress);
			RuleFor(x => x.ContactSubject).NotEmpty().WithMessage(Messages.ContactSubjectNotEmpty);
			RuleFor(x => x.ContactSubject).MinimumLength(5).WithMessage(Messages.ContactSubjectMinimumLength);
			RuleFor(x => x.ContactSubject).MaximumLength(50).WithMessage(Messages.ContactSubjectMaximumLength);
			RuleFor(x => x.ContactMessage).NotEmpty().WithMessage(Messages.ContactMessageNotEmpty);
			RuleFor(x => x.ContactMessage).MinimumLength(10).WithMessage(Messages.ContactMessageMinimumLength);
			RuleFor(x => x.ContactMessage).MaximumLength(1000).WithMessage(Messages.ContactMessageMaximumLength);
		}
	}
}
