using FastEndpoints;

using FluentValidation;
using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Validators.AbstractValidators;

namespace QuizMaker.Validetors.TeacherValidators;

public class AddQuizRetrievalValidator : Validator<AddQuizRequest>
{
    public AddQuizRetrievalValidator()
    {
        RuleFor(x => x.TeacherId)
            .NotNull().WithMessage("teacher id is null!")
            .NotEmpty().WithMessage("teacher id is required!");

        RuleFor(x => x.Questions)
            .NotNull().WithMessage("questions is null!")
            .NotEmpty().WithMessage("questions is required!");

        RuleForEach(x => x.Questions).SetValidator(new QuestionValidator());

        RuleFor(x => x.ExpiryDate)
            .GreaterThan(x => x.CreationTime)
            .WithMessage("an expiry date less than or equal to than creation time .");

        RuleFor(x => x.Duration)
            .GreaterThan(0)
            .WithMessage("please make sure quiz duration greater than zero .");

        RuleFor(x => x.RequiredStudents)
            .NotNull().WithMessage("students is null!")
            .NotEmpty().WithMessage("students is required!");

    }
}

