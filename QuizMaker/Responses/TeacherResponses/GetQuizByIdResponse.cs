using QuizMaker.Models;

namespace QuizMaker.Responses.TeacherResponses;

public class GetQuizByIdResponse
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public int Duration { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ICollection<Question>? Questions { get; set; }
    public ICollection<Guid>? RequiredStudents { get; set; }
    public ICollection<TestedStudent>? TestedStudents { get; set; }
}
