namespace QuizMaker.Responses.TeacherResponses;

public class StatisticsOnQuizResponse
{
    public int RequiredStudentsCount { get; set; }
    public int TestedStudentsCount { get; set; }
    public double StudentsAvarage { get; set; }
    public double MarksAvarage { get; set; }

    public bool IsExist { get; set; }
}