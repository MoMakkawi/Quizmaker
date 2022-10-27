using FastEndpoints;

using FluentValidation;

using QuizMaker.Models.DTOs;

namespace QuizMaker.Validators.AbstractValidators;

public class UserDTOValidator : Validator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("user id is null!")
            .NotEmpty().WithMessage("user id is required!");

        RuleFor(x => x.Email)
            .NotNull().WithMessage("email address is null!")
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress().WithMessage("the format of your email address is wrong!");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("your first name is required!")
            .MinimumLength(3).WithMessage("first name is too short!")
            .MaximumLength(25).WithMessage("first name is too long!");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("your last name is required!")
            .MinimumLength(3).WithMessage("last name is too short!")
            .MaximumLength(25).WithMessage("last name is too long!");

    }
}
