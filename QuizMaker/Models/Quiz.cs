namespace QuizMaker.Models;

public abstract class Quiz
{
    public Guid Id { get; set; }
    public string? TeacherId { get; set; }
    public DateTime CreationTime { get; set; }
    public int Duration { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual ICollection<Question>? Questions { get; set; }
}
