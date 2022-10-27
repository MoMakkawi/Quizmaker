using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.TeacherRequests;

namespace QuizMaker.Validetors.TeacherValidators;

public class GetQuizByIdRetrievalValidator : Validator<GetQuizByIdRequest>
{
    public GetQuizByIdRetrievalValidator()
    {
        RuleFor(x => x.QId)
            .NotNull().WithMessage("quiz id is null!")
            .NotEmpty().WithMessage("quiz id is required!");
    }
}
