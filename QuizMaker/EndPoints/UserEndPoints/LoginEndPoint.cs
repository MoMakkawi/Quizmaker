using FastEndpoints;

using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.UserEndPoints;

public class LoginEndPoint : Endpoint<LoginRequest, LoginResponse>
{
    public IAsyncUser? UserRepository { get; set; }
    public override void Configure()
    {
        Verbs(Http.POST);
        Routes("user/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        LoginResponse res = await UserRepository!.Login(req);
        await SendAsync(res, cancellation: ct);
    }
}
