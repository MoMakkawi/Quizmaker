using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Validators.AbstractValidators;

namespace QuizMaker.Validators.TeacherValidators;

public class UpdateQuizRetrievalValidator : Validator<UpdateQuizRequest>
{
    public UpdateQuizRetrievalValidator()
    {
        RuleFor(x => x.Id)
    .NotNull().WithMessage("quiz id is null!")
    .NotEmpty().WithMessage("quiz id is required!");

        RuleFor(x => x.Questions)
            .NotNull().WithMessage("questions is null!")
            .NotEmpty().WithMessage("questions is required!");

        RuleForEach(x => x.Questions).SetValidator(new QuestionValidator());

        RuleFor(x => x.Duration)
            .GreaterThan(0)
            .WithMessage("please make sure quiz duration greater than zero .");

        RuleFor(x => x.Teacher)
            .NotNull().WithMessage("students is null!")
            .NotEmpty().WithMessage("students is required!")
            .SetValidator(new UserDTOValidator()!);

        RuleFor(x => x.RequiredStudents)
            .NotNull().WithMessage("students is null!")
            .NotEmpty().WithMessage("students is required!");

        RuleForEach(x => x.RequiredStudents).SetValidator(new RequiredStudentValidator());
    }
}
