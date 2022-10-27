namespace QuizMaker.Models
{
    public class RequiredStudent
    {
        public Guid Id { get; set; }
        public string? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
