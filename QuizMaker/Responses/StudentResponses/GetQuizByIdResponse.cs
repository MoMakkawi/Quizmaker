using QuizMaker.Models.DTOs;
using QuizMaker.Models;

namespace QuizMaker.Responses.StudentResponses;

public class GetQuizByIdResponse
{
    public Guid Id { get; set; }
    public ICollection<Question>? Questions { get; set; }
    public UserDTO? Teacher { get; set; }
    public DateTime CreationTime { get; set; }
    public int Duration { get; set; }
    public DateTime ExpiryDate { get; set; }
    public double Mark { get; set; }
}
