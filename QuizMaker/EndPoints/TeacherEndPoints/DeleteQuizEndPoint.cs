using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class DeleteQuizEndPoint : Endpoint<DeleteQuizRequest>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("teacher/deletequiz/{Id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(DeleteQuizRequest req, CancellationToken ct)
        {
            await TeacherRepository!.DeleteQuizAsync(req);

            await SendAsync(
                new { message = "Deleted successfully" },
                cancellation: ct
                );
        }
    }
}
