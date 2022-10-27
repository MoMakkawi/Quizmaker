using FastEndpoints;

using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.EndPoints.TeacherEndPoints
{
    public class StatisticsOnQuizEndPoint:Endpoint<StatisticsOnQuizRequest,StatisticsOnQuizResponse>
    {
        public IAsyncTeacher? TeacherRepository { get; set; }
        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("teacher/statisticsforquiz/{QId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StatisticsOnQuizRequest req, CancellationToken ct)
        {
            var response = await TeacherRepository!.GetQuizStatistcalInformationAsync(req);
            await SendAsync(response, cancellation: ct);
        }
    }
}
