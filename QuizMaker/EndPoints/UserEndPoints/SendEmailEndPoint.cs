using FastEndpoints;

using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.UserEndPoints;

public class SendEmailEndPoint : Endpoint<SendEmailRequest, SendEmailResponse>
{
    public IAsyncUser? UserRepository { get; set; }
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("user/send/{From}/{To}/{Subject}/{Body}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SendEmailRequest req, CancellationToken ct)
    {
        SendEmailResponse resp = await UserRepository!.SendEmail(req);
        await SendAsync(resp, cancellation: ct);
    }
}
