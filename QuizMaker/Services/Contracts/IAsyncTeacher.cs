using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;

namespace QuizMaker.Services.Contracts
{
    public interface IAsyncTeacher
    {
        Task<AnswerStudentQuestionRespose> AddAnswerStudentQuestionAsync(AnswerStudentQuestionRequest request);
        Task<AddQuizResponse> AddQuizAsync(AddQuizRequest request);
        Task DeleteQuizAsync(DeleteQuizRequest request);
        Task<List<GetAllQuizzesResponse>> GetAllQuizzesAsync(GetAllQuizzesRequest request);
        Task<GetQuizByIdResponse> GetQuizByIdAsync(GetQuizByIdRequest request);
        Task<UpdateQuizResponse> UpdateQuizAsync(UpdateQuizRequest request);

        Task<StatisticsOnQuizResponse> GetQuizStatistcalInformationAsync(StatisticsOnQuizRequest request);
    }
}
