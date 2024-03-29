﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;

using QuizMaker.Data;
using QuizMaker.Identity;
using QuizMaker.Models.DTOs;
using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;
using QuizMaker.Services.Contracts;
using System.Net.Mail;
using FluentEmail.Core;

namespace QuizMaker.Services.Repositories
{
    public class UserRepository : IAsyncUser
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetAllStudentsResponse>> GetAllStudents(GetAllStudentsRequest req)
        {
            List<Student> students = await _dbContext.Students!
                .Where(s => s.Password != null)
                .ToListAsync();
            var response = _mapper.Map<List<GetAllStudentsResponse>>(students);
            return response;
        }

        public async Task<GetStudentsQuestionsAndTeachersAnswersResponse> GetStudentsQuestionsAndTeachersAnswersAsync(GetStudentsQuestionsAndTeachersAnswersRequest request)
        {
            var respose = new GetStudentsQuestionsAndTeachersAnswersResponse();
            respose.StudentQuestionAndTeaherAnswer = new List<StudentQuestionAndTeaherAnswerDTO>();

            foreach (var studentquestion in _dbContext.StudentQuestions)
            { 
                var StudentQuestionAndTeaherAnswer = new StudentQuestionAndTeaherAnswerDTO()
                {
                    StudentId = new Guid(studentquestion.StudentId!),
                    Question = studentquestion.Question,
                };

                var teacherAnswer = await _dbContext
                    .TeacherAnswers
                    .Where(a => a.StudentQuestionId == studentquestion.Id)
                    .FirstOrDefaultAsync();

                if (teacherAnswer is not null)
                {
                    StudentQuestionAndTeaherAnswer.TeacherId = teacherAnswer.StudentQuestionId;
                    StudentQuestionAndTeaherAnswer.Answer = teacherAnswer.Answer;
                }

                respose
                    .StudentQuestionAndTeaherAnswer!
                    .Add(StudentQuestionAndTeaherAnswer);

            }

            return respose;
        }

        public async Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest getUserByIdRequest)
        {
            GetUserByIdResponse response = new();

            User? user = await _dbContext.Teachers!.FindAsync(getUserByIdRequest.Id);
            user ??= await _dbContext.Students!.FindAsync(getUserByIdRequest.Id);

            if (user is null)
            {
                // IsExist = false by defult 
                return response;
            }

            response = _mapper.Map<GetUserByIdResponse>(user);
            response.IsExist = true;

            return response;

        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {

            LoginResponse resp = new();

            User? user = await _dbContext.Admins!
                .FirstOrDefaultAsync(t => t.Email == loginRequest.Email && t.Password == loginRequest.Password);
            user ??= await _dbContext.Teachers!
                .FirstOrDefaultAsync(t => t.Email == loginRequest.Email && t.Password == loginRequest.Password);
            user ??= await _dbContext.Students!
                .FirstOrDefaultAsync(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);

            if (user is null)
            {
                //resp.IsExist = false by defult  
                resp.ResponseMessage = "There is no account with this information, please check your email and password";
                return resp;
            }

            resp = _mapper.Map<LoginResponse>(user);
            resp.IsExist = true;
            if (user!.Role == Role.Admin)
                resp.ResponseMessage = $"Welcome Admin. {user.FirstName} {user.LastName}";
            else if (user!.Role == Role.Teacher)
                resp.ResponseMessage = $"Welcome Mr. {user.FirstName} {user.LastName}";
            else resp.ResponseMessage = $"Welcome student , {user.FirstName} {user.LastName}";


            return resp;

        }

        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {

            RegisterResponse response = new();

            if (await _dbContext.Admins!.AnyAsync(a => a.Email == registerRequest.Email) ||
                await _dbContext.Teachers!.AnyAsync(t => t.Email == registerRequest.Email) ||
                await _dbContext.Students!.AnyAsync(s => s.Email == registerRequest.Email))
            {
                response.ResponseMessage = "There is an account with this email .";
                return response;
            }

            if (registerRequest.Role is Role.Student)
            {
                Student student = _mapper.Map<Student>(registerRequest);
                await _dbContext.Students!.AddAsync(student);
            }
            else
            {
                Teacher teacher = _mapper.Map<Teacher>(registerRequest);
                await _dbContext.Teachers!.AddAsync(teacher);
            }
            await _dbContext.SaveChangesAsync();
            response.ResponseMessage = "Account has been successfully registered .";
            return response;

        }

        public async Task<SendEmailResponse> SendEmail(SendEmailRequest sendEmailRequest)
        {


            SendEmailResponse response = new();
            try
            { 

                var x = await Email
                    .From(sendEmailRequest.From)
                    .To(sendEmailRequest.To, new MailAddress(sendEmailRequest.To!).User)
                    .Subject(sendEmailRequest.Subject)
                    .Body(sendEmailRequest.Body)
                    .SendAsync();


            response.ResponseMessage = "Message has been sent successfully .";
            }
            catch (Exception e)
            {
                response.ResponseMessage = "An error occurred while sending the message . \n" +
                    $" Error : {e.Message}";
            }

            return response;
        }
    }
}
