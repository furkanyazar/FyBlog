using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage(Messages.MessageSubjectNotEmpty);
            RuleFor(x => x.MessageSubject).MinimumLength(2).WithMessage(Messages.MessageSubjectMinimumLength);
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage(Messages.MessageSubjectMaximumLength);
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage(Messages.MessageContentNotEmpty);
            RuleFor(x => x.MessageContent).MinimumLength(5).WithMessage(Messages.MessageContentMinimumLength);
            RuleFor(x => x.MessageContent).MaximumLength(1000).WithMessage(Messages.MessageContentMaximumLength);
        }
    }
}
