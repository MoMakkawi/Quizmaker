using FluentValidation;
using QuizMaker.Models;

namespace QuizMaker.Validators.AbstractValidators;

public class AnswerValidator : AbstractValidator<Answer>
{
    public AnswerValidator()
    {
        RuleFor(a => a.AText)
            .NotNull().WithMessage("answer text is null!")
            .NotEmpty().WithMessage("answer text is required!");
    }
}
