using Microsoft.Build.Framework;

namespace QuizMaker.Models
{
    public class StudentQuestion
    {
        public Guid Id { get; set; }
        public string? StudentId { get; set; }
        public string? Question { get; set; }

    }
}
