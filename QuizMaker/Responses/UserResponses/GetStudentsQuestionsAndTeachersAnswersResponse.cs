using QuizMaker.Models.DTOs;

namespace QuizMaker.Responses.UserResponses
{
    public class GetStudentsQuestionsAndTeachersAnswersResponse
    {
        public ICollection<StudentQuestionAndTeaherAnswerDTO>? StudentQuestionAndTeaherAnswer { get; set; }
    }
}
