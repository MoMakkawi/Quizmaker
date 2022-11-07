namespace QuizMaker.Requests.UserRequests;
public class SendEmailRequest
{
    public string? From { get; set; }
    public string? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? SenderEmailPassword { get; set; }
}