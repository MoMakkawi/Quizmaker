using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.UserRequests;

namespace QuizMaker.Validetors
{
    public class LoginRetrievalValidator : Validator<LoginRequest>
    {
        public LoginRetrievalValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("email address is null!")
                .NotEmpty().WithMessage("email address is required!")
                .EmailAddress().WithMessage("the format of your email address is wrong!");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("a password is null!")
                .NotEmpty().WithMessage("a password is required!");
        }
    }
}
