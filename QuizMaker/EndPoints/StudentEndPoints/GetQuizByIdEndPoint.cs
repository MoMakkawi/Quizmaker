using FastEndpoints;

using QuizMaker.Requests.StudentRequests;
using QuizMaker.Responses.StudentResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.StudentEndPoints
{
    public class GetQuizByIdEndPoint : Endpoint<GetQuizByIdRequest,GetQuizByIdResponse>
    {
        public IAsyncStudent? StudentRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("student/getquizbyid/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetQuizByIdRequest req, CancellationToken ct)
        {
            var response = await StudentRepository!.GetQuizById(req);

            await SendAsync(response, cancellation: ct);
        }
    }
}
