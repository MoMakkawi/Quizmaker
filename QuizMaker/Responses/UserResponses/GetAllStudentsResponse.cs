using QuizMaker.Models;

namespace QuizMaker.Responses.UserResponses
{
    public class GetAllStudentsResponse
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Level Level { get; set; }
    }
}
