namespace QuizMaker.Requests.TeacherRequests
{
    public class AnswerStudentQuestionRequest
    {
        public Guid TeacherId { get; set; }
        public Guid StudentQuestionId { get; set; }
        public string? Answer { get; set; }
    }
}
