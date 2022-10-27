
using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.StudentRequests;

namespace QuizMaker.Validetors.StudentValidators;

public class GetQuizByIdRetrievalValidator : Validator<GetQuizByIdRequest>
{
	public GetQuizByIdRetrievalValidator()
	{
        RuleFor(x => x.Id)
            .NotNull().WithMessage("quiz id is null!")
            .NotEmpty().WithMessage("quiz id is required!");
    }
}
