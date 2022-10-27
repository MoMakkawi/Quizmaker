namespace QuizMaker.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string? AText { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsSelected { get; set; }
    }
}
