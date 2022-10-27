using FastEndpoints;

using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.UserEndPoints
{
    public class GetUserByIdEndPoint : Endpoint<GetUserByIdRequest, GetUserByIdResponse>
    {
        public IAsyncUser? UserRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("user/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetUserByIdRequest req, CancellationToken ct)
        {
            GetUserByIdResponse response = await UserRepository!.GetUserById(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
