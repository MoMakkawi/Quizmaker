using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaker.Models
{
    public class TeacherAnswer
    {
        public Guid Id { get; set; }
        [ForeignKey("StudentQuestion")]
        public string? StudentQuestionId { get; set; }
        public string? TeacherId { get; set; }
        public string? Answer { get; set; }
    }
}
