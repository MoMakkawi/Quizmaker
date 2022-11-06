using QuizMaker.Models;

namespace QuizMaker.Requests.TeacherRequests;

public class AddQuizRequest
{
    public ICollection<Question>? Questions { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime CreationTime => DateTime.UtcNow;
    public int Duration { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ICollection<Guid>? RequiredStudentsIds { get; set; }
}
