using System.ComponentModel.DataAnnotations.Schema;

using QuizMaker.Identity;

namespace QuizMaker.Models
{
    public class TeacherQuiz : Quiz
    {
        public virtual ICollection<Student>? RequiredStudents { get; set; }
        public virtual ICollection<TestedStudent>? TestedStudents { get; set; }

    }
}
