using System.Net.Mail;

namespace QuizMaker.Requests.UserRequests
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
