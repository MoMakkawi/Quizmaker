using AutoMapper;

using Microsoft.EntityFrameworkCore;

using QuizMaker.Data;
using QuizMaker.Models;
using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.Services.Repositories
{
    public class TeacherRepository : IAsyncTeacher
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;
        public TeacherRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AddQuizResponse> AddQuizAsync(AddQuizRequest request)
        {

            TeacherQuiz TQuiz = _mapper.Map<TeacherQuiz>(request);

            await _dbContext.TeacherQuizzes!.AddAsync(TQuiz);
            await _dbContext.SaveChangesAsync();

            AddQuizResponse response = new() { Id = TQuiz.Id };    

            return response;
        }

        public async Task DeleteQuizAsync(DeleteQuizRequest request)
        {
            TeacherQuiz? quiz = await _dbContext.TeacherQuizzes!.FindAsync(request.Id);
            if (quiz == null) return;

            _dbContext.TeacherQuizzes!.Remove(quiz!);
            _dbContext.SaveChanges();
        }

        public async Task<List<GetAllQuizzesResponse>> GetAllQuizzesAsync(GetAllQuizzesRequest request)
        {
            List<TeacherQuiz> teacherQuizzes = await _dbContext.TeacherQuizzes!.ToListAsync();
            var teacherQuizzesResponses = _mapper.Map<List<GetAllQuizzesResponse>>(teacherQuizzes);
            return teacherQuizzesResponses;
        }

        public async Task<GetQuizByIdResponse> GetQuizByIdAsync(GetQuizByIdRequest request)
        {
            TeacherQuiz? teacherQuizze = await _dbContext.TeacherQuizzes!.FindAsync(request.QId);
            GetQuizByIdResponse response = _mapper.Map<GetQuizByIdResponse>(teacherQuizze);

            return response;
        }

        public async Task<StatisticsOnQuizResponse> GetQuizStatistcalInformationAsync(StatisticsOnQuizRequest request)
        {
            StatisticsOnQuizResponse response = new();
            TeacherQuiz? TeacherQuiz = await _dbContext.TeacherQuizzes!.FindAsync(request.QId);
            if (TeacherQuiz is null)
            {
                //response.IsExist = false; <- BY DEFAULT
                return response;
            }

            int requiredStudentsCount = TeacherQuiz.RequiredStudents!.Count;
            int testedStudentsCount = TeacherQuiz.TestedStudents!.Count;
            double studentsAvarage = requiredStudentsCount / testedStudentsCount;

            double marks = TeacherQuiz.TestedStudents!.Sum(ts => ts.Mark);
            double marksAvarage = marks / testedStudentsCount;

            response = new()
            {
                IsExist = true,
                RequiredStudentsCount = requiredStudentsCount,
                TestedStudentsCount = testedStudentsCount,
                StudentsAvarage = studentsAvarage,
                MarksAvarage = marksAvarage,
            };

            return response;
        }

        public async Task<UpdateQuizResponse> UpdateQuizAsync(UpdateQuizRequest request)
        {
            TeacherQuiz teacherQuiz = _mapper.Map<TeacherQuiz>(request);

            _dbContext.Entry(teacherQuiz).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            UpdateQuizResponse response = new() { Id = teacherQuiz.Id };
            return response;
        }
    }
}
