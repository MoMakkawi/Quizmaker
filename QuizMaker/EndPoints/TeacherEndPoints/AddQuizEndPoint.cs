using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class AddQuizEndPoint : Endpoint<AddQuizRequest, AddQuizResponse>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("teacher/addquiz");
            AllowAnonymous();
        }
        public override async Task HandleAsync(AddQuizRequest req, CancellationToken ct)
        {
            var response = await TeacherRepository!.AddQuizAsync(req);

            await SendAsync(response, cancellation: ct);
        }
    }
}
