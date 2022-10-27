using QuizMaker.Models.DTOs;

namespace QuizMaker.Models
{
    public class TeacherQuiz : Quiz
    {
        public virtual ICollection<RequiredStudent>? RequiredStudents { get; set; }
        public virtual ICollection<TestedStudent>? TestedStudents { get; set; }
    }
}
