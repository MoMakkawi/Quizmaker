using FluentValidation;
using QuizMaker.Models;

namespace QuizMaker.Validators.AbstractValidators;
public class QuestionValidator : AbstractValidator<Question>
{
	public QuestionValidator()
	{

        RuleFor(x => x.QText)
            .NotNull().WithMessage("question text is null!")
            .NotEmpty().WithMessage("question text is required!");

        RuleForEach(x => x.Answers).SetValidator(new AnswerValidator());

        RuleFor(x => x.Answers)
            .NotNull().WithMessage("answers is null!")
            .NotEmpty().WithMessage("answers is required!");


    }
}
