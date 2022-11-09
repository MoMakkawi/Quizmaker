using FastEndpoints;

using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.UserEndPoints
{
    public class GetAllStudentsEndPoint : Endpoint<GetAllStudentsRequest,List<GetAllStudentsResponse>>
    {
        public IAsyncUser? UserRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("user/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetAllStudentsRequest req, CancellationToken ct)
        {
            var response = await UserRepository!.GetAllStudents(req);
            await SendAsync(response);
        }
    }
}
