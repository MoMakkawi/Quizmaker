using FastEndpoints;

using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.UserEndPoints
{
    public class GetStudentsQuestionsAndTeachersAnswersEndPoint 
        : Endpoint<GetStudentsQuestionsAndTeachersAnswersRequest,GetStudentsQuestionsAndTeachersAnswersResponse>
    {
        public IAsyncUser? UserRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("user/GetStudentsQuestionsAndTeachersAnswersRequest");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetStudentsQuestionsAndTeachersAnswersRequest req, CancellationToken ct)
        {
            var response = await UserRepository!.GetStudentsQuestionsAndTeachersAnswersAsync(req);
            await SendAsync(response);
        }
    }
}
