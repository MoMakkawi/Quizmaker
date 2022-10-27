using FastEndpoints;

using QuizMaker.Requests.StudentRequests;
using QuizMaker.Responses.StudentResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.StudentEndPoints
{
    public class GetAllQuizzesEndPoint : Endpoint<GetAllQuizzesRequest,List<GetAllQuizzesResponse>>
    {
        public IAsyncStudent? StudentRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("student/getallquizzes");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetAllQuizzesRequest req, CancellationToken ct)
        {
            var response = await StudentRepository!.GetAllQuizzes(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
