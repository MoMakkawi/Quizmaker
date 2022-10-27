
using QuizMaker.Models.DTOs;
using QuizMaker.Models;

namespace QuizMaker.Requests.TeacherRequests;

public class UpdateQuizRequest
{
    public Guid Id { get; set; }
    public ICollection<Question>? Questions { get; set; }
    public UserDTO? Teacher { get; set; }
    public int Duration { get; set; }
    public DateTime ExpiryDate { get; set; }
    public ICollection<RequiredStudent>? RequiredStudents { get; set; }
}
