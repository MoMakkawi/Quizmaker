using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class AnswerStudentQuestionEndPoint : Endpoint<AnswerStudentQuestionRequest,AnswerStudentQuestionRespose>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("teacher/answerstudentquestion/{TeacherId}/{StudentQuestionId}/{Answer}");
            AllowAnonymous();
        }

        public async override Task HandleAsync(AnswerStudentQuestionRequest req, CancellationToken ct)
        {
            var response = await TeacherRepository!.AddAnswerStudentQuestionAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
