using QuizMaker.Models.DTOs;
using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;

namespace QuizMaker.Services.Contracts
{
    public interface IAsyncUser
    {
        Task<GetStudentsQuestionsAndTeachersAnswersResponse> GetStudentsQuestionsAndTeachersAnswersAsync(GetStudentsQuestionsAndTeachersAnswersRequest request);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
        Task<SendEmailResponse> SendEmail(SendEmailRequest sendEmailRequest);
        Task<GetUserByIdResponse> GetUserById (GetUserByIdRequest getUserByIdRequest);
    }
}
