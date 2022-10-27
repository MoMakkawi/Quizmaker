using QuizMaker.Models;

namespace QuizMaker.Identity;

public class Teacher : User
{
    public virtual ICollection<TeacherQuiz>? Quizzes { get; set; }
}
