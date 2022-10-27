using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class UpdateQuizEndPoint : Endpoint<UpdateQuizRequest,UpdateQuizResponse>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("teacher/updatequiz");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateQuizRequest req, CancellationToken ct)
        {
            var response = await TeacherRepository!.UpdateQuizAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
