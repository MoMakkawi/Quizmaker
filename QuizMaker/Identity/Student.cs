using QuizMaker.Models;

namespace QuizMaker.Identity
{
    public class Student : User
    {
        public Level Level { get; set; }
        public virtual ICollection<StudentQuiz>? Quizzes { get; set; }
    }
}
