using FluentValidation;

using QuizMaker.Models;

namespace QuizMaker.Validators.AbstractValidators
{
    public class RequiredStudentValidator : AbstractValidator<RequiredStudent>
    {
        public RequiredStudentValidator()
        {
            RuleFor(x => x.StudentId)
                .NotNull().WithMessage("student id is null!")
                .NotEmpty().WithMessage("student id is required!");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("student email address is null!")
                .NotEmpty().WithMessage("student email address is required!")
                .EmailAddress().WithMessage("the format of your email address is wrong!");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("student first name is required!")
                .MinimumLength(3).WithMessage("student name is too short!")
                .MaximumLength(25).WithMessage("student name is too long!");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("student last name is required!")
                .MinimumLength(3).WithMessage("student last name is too short!")
                .MaximumLength(25).WithMessage("student last name is too long!");

        }
    }
}
