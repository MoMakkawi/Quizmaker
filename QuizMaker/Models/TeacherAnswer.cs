using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaker.Models
{
    public class TeacherAnswer
    {
        public Guid Id { get; set; }

        public string? TeacherId { get; set; }
        public string? Answer { get; set; }

        public Guid StudentQuestionId { get; set; }
        [ForeignKey("StudentQuestionId")]
        public virtual StudentQuestion? StudentQuestion { get; set; }
    }
}
