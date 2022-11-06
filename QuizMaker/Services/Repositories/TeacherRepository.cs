using AutoMapper;

using Microsoft.EntityFrameworkCore;

using QuizMaker.Data;
using QuizMaker.Identity;
using QuizMaker.Models;
using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.TeacherResponses;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;

namespace QuizMaker.Services.Repositories
{
    public class TeacherRepository : IAsyncTeacher
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IAsyncUser? _userRepository;
        protected readonly IMapper _mapper;
        public TeacherRepository(ApplicationDbContext dbContext, IMapper mapper , IAsyncUser? userRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<AddQuizResponse> AddQuizAsync(AddQuizRequest request)
        {

            TeacherQuiz TQuiz = _mapper.Map<TeacherQuiz>(request);
            TQuiz.RequiredStudents = await GetStudents(request.RequiredStudentsIds!);


            await _dbContext.TeacherQuizzes!.AddAsync(TQuiz);
            await _dbContext.SaveChangesAsync();

            AddQuizResponse response = new() { Id = TQuiz.Id };    

            return response;
        }

        private async Task<ICollection<Student>?> GetStudents(ICollection<Guid> StudentsIds)
        {
            var students = new List<Student>();
            foreach (var studentId in StudentsIds!)
            {
                var student = await GetStudentById(studentId);
                students.Add(student);
            }
            return students;
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
            for (int i = 0; i < teacherQuizzes.Count; i++)
            {
                teacherQuizzesResponses[i].RequiredStudents = teacherQuizzes[i]!.RequiredStudents!
                    .Select(s => s.Id).ToList();
            }
            return teacherQuizzesResponses;
        }

        public async Task<GetQuizByIdResponse> GetQuizByIdAsync(GetQuizByIdRequest request)
        {
            TeacherQuiz? teacherQuizze = await _dbContext.TeacherQuizzes!.FindAsync(request.QId);
            GetQuizByIdResponse response = _mapper.Map<GetQuizByIdResponse>(teacherQuizze);
            response.RequiredStudents = teacherQuizze!.RequiredStudents!.Select(s => s.Id).ToList();
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

            if (testedStudentsCount is 0)
            {
                response = new()
                {
                    IsExist = true,
                    RequiredStudentsCount = requiredStudentsCount,
                    TestedStudentsCount = 0,
                    StudentsAvarage = 0,
                    MarksAvarage = 0,
                };
                return response;
            }

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
            teacherQuiz.RequiredStudents = await GetStudents(request.RequiredStudentsIds!);

            _dbContext.Entry(teacherQuiz).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            UpdateQuizResponse response = new() { Id = teacherQuiz.Id };
            return response;
        }

        #region Helper Methods
        private async Task<Student> GetStudentById(Guid id)
        {
            GetUserByIdRequest getUserRequest = new()
            {
                Id = id
            };
            GetUserByIdResponse getUserResponse = await _userRepository!.GetUserById(getUserRequest);

            var student = _mapper.Map<Student>(getUserResponse);

            return student;
        }
        #endregion
    }
}
