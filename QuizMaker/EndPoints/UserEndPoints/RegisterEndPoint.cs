using FastEndpoints;

using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.UserEndPoints;

public class RegisterEndPoint : Endpoint<RegisterRequest,RegisterResponse>
{
    public IAsyncUser? UserRepository { get; set; }

    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("user/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        RegisterResponse res = await UserRepository!.Register(req);
        await SendAsync(res, cancellation: ct);
    }
}
