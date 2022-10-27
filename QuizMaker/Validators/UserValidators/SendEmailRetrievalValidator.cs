using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.UserRequests;

namespace QuizMaker.Validetors.UserValidators;

public class SendEmailRetrievalValidator : Validator<SendEmailRequest>
{
    public SendEmailRetrievalValidator()
    {
        RuleFor(x => x.From)
            .NotNull().WithMessage("email address is null!")
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress().WithMessage("the format of your email address is wrong!");

        RuleFor(x => x.To)
            .NotNull().WithMessage("email address is null!")
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress().WithMessage("the format of your email address is wrong!");

        RuleFor(x => x.Subject)
            .NotNull().WithMessage("subject is null!")
            .NotEmpty().WithMessage("subject is required!")
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Body)
            .NotNull().WithMessage("message body is null!")
            .NotEmpty().WithMessage("message body is required!")
            .MinimumLength(2)
            .MaximumLength(2000);


    }
}
