using QuizMaker.Models;

namespace QuizMaker.Requests.StudentRequests
{
    public class SolveQuizRequest
    {
        public Guid TeacherQuizId { get; set; }
        public Guid StudentId { get; set; }
        public bool IsLevelQuiz { get; set; }
        public ICollection<Answer>? Answers { get; set; }

    }
}
