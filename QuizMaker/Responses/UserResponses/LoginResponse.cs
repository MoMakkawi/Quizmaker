using QuizMaker.Identity;

namespace QuizMaker.Responses.UserResponses;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    public bool IsExist { get; set; }
    public string? ResponseMessage { get; set; }
}
