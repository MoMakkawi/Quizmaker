using System.ComponentModel.DataAnnotations.Schema;

using QuizMaker.Identity;

namespace QuizMaker.Models;

public abstract class Quiz
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public int Duration { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsLevelQuiz { get; set; }
    public virtual ICollection<Question>? Questions { get; set; }
    public Guid TeacherId { get; set; }
    [ForeignKey(nameof(TeacherId))]
    public Teacher? Teacher { get; set; }
}
