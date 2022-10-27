using System.Text.RegularExpressions;

using FastEndpoints;

using FluentValidation;

using QuizMaker.Requests.UserRequests;

namespace QuizMaker.Validetors.UserValidators;

public class RegisterRetrevialValidator : Validator<RegisterRequest>
{
	public RegisterRetrevialValidator()
	{
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

        RuleFor(x => x.Password)
            .NotNull().WithMessage("a password is null!")
            .NotEmpty().WithMessage("a password is required!")
            .Must(HasValidPassword)
            .WithMessage("The password must contain symbols, numbers, uppercase and lowercase letters");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("role not found");
    }
    private bool HasValidPassword(string? pw)
    {
        Regex lowercase = new("[a-z]+");
        Regex uppercase = new ("[A-Z]+");
        Regex digit = new ("(\\d)+");
        Regex symbol = new ("(\\W)+");

        return lowercase.IsMatch(pw!) &&
            uppercase.IsMatch(pw!) &&
            digit.IsMatch(pw!) &&
            symbol.IsMatch(pw!);
    }
}
