using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage(Messages.CategoryNameNotEmpty);
			RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage(Messages.CategoryNameMinimumLength);
			RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage(Messages.CategoryNameMaximumLength);
			RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage(Messages.CategoryDescriptionMinimumLength);
			RuleFor(x => x.CategoryDescription).MaximumLength(50).WithMessage(Messages.CategoryDescriptionMaximumLength);
		}
	}
}
