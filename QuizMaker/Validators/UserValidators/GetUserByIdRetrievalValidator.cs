using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.UserRequests;

namespace QuizMaker.Validetors.UserValidators;

public class GetUserByIdRetrievalValidator : Validator<GetUserByIdRequest>
{
    public GetUserByIdRetrievalValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("user id is null!")
            .NotEmpty().WithMessage("user id is required!");
    }
}
