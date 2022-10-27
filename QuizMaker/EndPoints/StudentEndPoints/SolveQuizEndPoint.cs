using FastEndpoints;

using QuizMaker.Requests.StudentRequests;
using QuizMaker.Responses.StudentResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.StudentEndPoints
{
    public class SolveQuizEndPoint : Endpoint<SolveQuizRequest,SolveQuizResponse>
    {
        public IAsyncStudent? StudentRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("student/solvequiz");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SolveQuizRequest req, CancellationToken ct)
        {
            SolveQuizResponse response = await StudentRepository!.SolveQuiz(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
