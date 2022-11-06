using FastEndpoints;

using QuizMaker.Requests.StudentRequests;
using QuizMaker.Responses.StudentResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.StudentEndPoints
{
    public class AskQuestionEndPoint : Endpoint<AskQuestionRequest, AskQuestionResponse>
    {
        public IAsyncStudent? StudentRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("student/askquestion");
            AllowAnonymous();
        }

        public async override Task HandleAsync(AskQuestionRequest req, CancellationToken ct)
        {
            AskQuestionResponse response = await StudentRepository!.AddQuestionAsync(req);

            await SendOkAsync(response, ct);
        }
    }
}
