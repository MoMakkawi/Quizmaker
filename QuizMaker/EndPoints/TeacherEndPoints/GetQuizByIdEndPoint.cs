using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class GetQuizByIdEndPoint : Endpoint<GetQuizByIdRequest,GetQuizByIdResponse>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("teacher/getquizbyid/{QId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetQuizByIdRequest req, CancellationToken ct)
        {
            var response = await TeacherRepository!.GetQuizByIdAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
