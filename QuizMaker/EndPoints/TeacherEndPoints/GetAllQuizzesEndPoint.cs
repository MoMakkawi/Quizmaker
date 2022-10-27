using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class GetAllQuizzesEndPoint : Endpoint<GetAllQuizzesRequest,List<GetAllQuizzesResponse>>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("teacher/getallquizzes");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetAllQuizzesRequest req, CancellationToken ct)
        {
            List<GetAllQuizzesResponse> response = await TeacherRepository!.GetAllQuizzesAsync(req);

            await SendAsync(response, cancellation: ct);
        }
    }
}
