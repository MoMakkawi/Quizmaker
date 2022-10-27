using AutoMapper;

using Microsoft.EntityFrameworkCore;
using QuizMaker.Data;
using QuizMaker.Models;
using QuizMaker.Models.DTOs;
using QuizMaker.Requests.StudentRequests;
using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.StudentResponses;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.Services.Repositories;

public class StudentRepository : IAsyncStudent
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly IMapper _mapper;
    protected readonly IAsyncUser? _userRepository;
    public StudentRepository(ApplicationDbContext dbContext, IMapper mapper , IAsyncUser? userRepository)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<List<GetAllQuizzesResponse>> GetAllQuizzes(GetAllQuizzesRequest request)
    {
        List<StudentQuiz> studentQuizzes = await _dbContext.StudentQuizzes!.ToListAsync();
        List<GetAllQuizzesResponse> studentQuizzesResponses = _mapper.Map<List<GetAllQuizzesResponse>>(studentQuizzes);

        for (int i = 0; i < studentQuizzesResponses.Count; i++)
        {
            studentQuizzesResponses
                .ElementAt(i)
                .Teacher = await GetTeacherById(studentQuizzes.ElementAt(i).TeacherId!);
        }

        return studentQuizzesResponses;
    }

    public async Task<GetQuizByIdResponse> GetQuizById(GetQuizByIdRequest request)
    {
        StudentQuiz? studentQuiz = await _dbContext.StudentQuizzes!.FindAsync(request.Id);
        GetQuizByIdResponse response = _mapper.Map<GetQuizByIdResponse>(studentQuiz);
        response.Teacher = await GetTeacherById(studentQuiz!.TeacherId!);

        return response;

    }

    public async Task<SolveQuizResponse> SolveQuiz(SolveQuizRequest request)
    {
        double mark = GetMark(request.Answers!);
        Level level = GetLevel(mark);

        SolveQuizResponse response = new() { Mark = mark };

        TeacherQuiz? teacherQuiz = await _dbContext.TeacherQuizzes!.FindAsync(request.TeacherQuizId);
        if (teacherQuiz is null) return response;
  
        teacherQuiz.TestedStudents!
            .Add(GetTestedStudent(request , mark));

        await _dbContext.StudentQuizzes!
            .AddAsync(GetStudentQuiz(teacherQuiz, mark , request.Answers!));


        if (request.IsLevelQuiz) UpdateStudentLevel(request.StudentId, level);

        await _dbContext.SaveChangesAsync();
        
        
        return response;
    }



    #region Helper Methods
    private static StudentQuiz GetStudentQuiz(TeacherQuiz teacherQuiz, double mark, ICollection<Answer> studentAnswers) => new()
    {
        Mark = mark,
        Duration = teacherQuiz!.Duration,
        CreationTime = teacherQuiz!.CreationTime,
        ExpiryDate = teacherQuiz!.ExpiryDate,
        TeacherId = teacherQuiz.TeacherId,
        Questions = UpdateForStudentAnswer(teacherQuiz.Questions!, studentAnswers)
    };
    private static Level GetLevel(double mark) => mark switch
    {
        < 17 => Level.A1,
        < 34 => Level.A2,
        < 51 => Level.B1,
        < 67 => Level.B2,
        < 84 => Level.C1,
        <= 100 => Level.C2,
        _ => Level.A1,
    };
    private static double GetMark(ICollection<Answer> answers)
    {
        int correctAnswers = answers!.Count(a => a.IsCorrect);
        int studentAnswers = answers!.Count(a => a.IsSelected && a.IsCorrect)
            - answers!.Count(a => a.IsSelected && !a.IsCorrect) //selecte uncorrect answer
            - answers!.Count(a => !a.IsSelected && a.IsCorrect); // correct answer didn't selected

        double Mark;
        try
        {
            Mark = Convert.ToDouble(studentAnswers / correctAnswers);
        }
        catch
        {
            Mark = 0;
        }

        return Mark >= 0 ? Mark : 0;
    }
    private static TestedStudent GetTestedStudent(SolveQuizRequest request, double mark) => new()
    {
        Mark = mark,
        StudentId = request.StudentId.ToString(),
        QuizId = request.TeacherQuizId.ToString(),
    };
    private async void UpdateStudentLevel(Guid studentId, Level level)
    {
        var student = await _dbContext.Students!.FirstOrDefaultAsync(u => u.Id == studentId);
        if (student is not null)
        {
            student!.Level = level;
            _dbContext.Students!.Update(student!);
        }
    }
    private static ICollection<Question> UpdateForStudentAnswer(ICollection<Question> questions, ICollection<Answer> sAnswers)
    {
        questions = questions.Select(q =>
        {
            q.Answers = q.Answers!
            .Select(a => sAnswers.FirstOrDefault(sa => sa.Id == a.Id))
            .ToList()!;

            return q;

        }).ToList();

        return questions;
    }
    private async Task<UserDTO> GetTeacherById(string id)
    {
        GetUserByIdRequest getUserRequest = new()
        {
            Id = new Guid(id)
        };
        GetUserByIdResponse getUserResponse = await _userRepository!.GetUserById(getUserRequest);

        var teacher = _mapper.Map<UserDTO>(getUserResponse);
        teacher.Id = getUserRequest.Id;

        return teacher;
    }
    #endregion Helper Methods
}
