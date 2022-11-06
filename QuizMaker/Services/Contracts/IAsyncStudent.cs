using QuizMaker.Requests.StudentRequests;
using QuizMaker.Responses.StudentResponses;

namespace QuizMaker.Services.Contracts
{
    public interface IAsyncStudent
    {
        Task<AskQuestionResponse> AddQuestionAsync(AskQuestionRequest request);
        Task<List<GetAllQuizzesResponse>> GetAllQuizzes(GetAllQuizzesRequest request);
        Task<GetQuizByIdResponse> GetQuizById(GetQuizByIdRequest request);
        Task<SolveQuizResponse> SolveQuiz(SolveQuizRequest request);
    }
}
