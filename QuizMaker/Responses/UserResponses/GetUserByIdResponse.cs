using QuizMaker.Identity;

namespace QuizMaker.Responses.UserResponses;

public class GetUserByIdResponse
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }

    public bool IsExist { get; set; }
}
