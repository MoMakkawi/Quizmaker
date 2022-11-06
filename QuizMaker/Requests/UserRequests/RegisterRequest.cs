using QuizMaker.Identity;
using System.Net.Mail;

namespace QuizMaker.Requests.UserRequests;

public class RegisterRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Role Role { get; set; }
}