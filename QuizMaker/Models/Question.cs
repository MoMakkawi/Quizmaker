namespace QuizMaker.Models;

public class Question
{
    public Guid Id { get; set; }
    public string? QText { get; set; }
    public virtual ICollection<Answer>? Answers { get; set; }
}
