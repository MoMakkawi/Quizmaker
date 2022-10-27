using FastEndpoints;

using FluentValidation;
using QuizMaker.Requests.StudentRequests;
using QuizMaker.Validators.AbstractValidators;

namespace QuizMaker.Validetors.StudentValidators;

public class SolveQuizRetrievalValidator : Validator<SolveQuizRequest>
{
    public SolveQuizRetrievalValidator()
    {
        RuleFor(x => x.StudentId)
            .NotNull().WithMessage("student id is null!")
            .NotEmpty().WithMessage("student id is required!");

        RuleFor(x => x.TeacherQuizId)
            .NotNull().WithMessage("quiz id is null!")
            .NotEmpty().WithMessage("quiz id is required!");

        RuleFor(x => x.Answers)
            .NotNull().WithMessage("answers is null!")
            .NotEmpty().WithMessage("answers is required!");

        RuleForEach(x => x.Answers).SetValidator(new AnswerValidator());
    }
}
