namespace QuizMaker.Models;

public class TestedStudent
{
    public Guid Id { get; set; }
    public string? StudentId { get; set; }
    public string? QuizId { get; set; }
    public double Mark { get; set; }
}
