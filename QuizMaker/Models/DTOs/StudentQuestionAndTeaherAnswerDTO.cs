namespace QuizMaker.Models.DTOs
{
    public class StudentQuestionAndTeaherAnswerDTO
    {
        public Guid StudentId { get; set; }
        public string? Question { get; set; }
        public Guid TeacherId { get; set; }
        public string? Answer { get; set; }
    }
}
