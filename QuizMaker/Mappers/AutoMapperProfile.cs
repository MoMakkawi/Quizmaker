using AutoMapper;

using QuizMaker.Identity;
using QuizMaker.Models;
using QuizMaker.Models.DTOs;
using QuizMaker.Requests.TeacherRequests;
using QuizMaker.Requests.UserRequests;
using QuizMaker.Responses.UserResponses;

namespace QuizMaker.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //student mapping
        CreateMap<StudentQuiz, Responses.StudentResponses.GetAllQuizzesResponse>()
            .ReverseMap();

        CreateMap<StudentQuiz, Responses.StudentResponses.GetQuizByIdResponse>()
            .ReverseMap();

        CreateMap<Requests.StudentRequests.AskQuestionRequest, StudentQuestion>()
            .ForMember(src => src.Id, opt => opt.Ignore())
            .ReverseMap();

        //teacher mapping
        CreateMap<AddQuizRequest, TeacherQuiz>()
            .ReverseMap();

        CreateMap<TeacherQuiz, Responses.TeacherResponses.GetAllQuizzesResponse>()
            .ForMember(src => src.RequiredStudents, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<TeacherQuiz, Responses.TeacherResponses.GetQuizByIdResponse>()
            .ForMember(src => src.RequiredStudents, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateQuizRequest, TeacherQuiz>()
            .ForMember(src => src.RequiredStudents, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<AnswerStudentQuestionRequest, TeacherAnswer>()
            .ForMember(src => src.Id , opt => opt.Ignore())
            .ReverseMap();



        //user mapping
        //CreateMap<User, UserDTO>()
        //    .ReverseMap();
        CreateMap<User, Teacher>()
            .ReverseMap();
        CreateMap<UserDTO, Teacher>()
            .ReverseMap();
        CreateMap<User, Student>()
            .ReverseMap();
        CreateMap<UserDTO, Student>()
            .ReverseMap();

        CreateMap<Teacher, GetUserByIdResponse>()
            .ReverseMap();

        CreateMap<Student, GetUserByIdResponse>()
            .ReverseMap();

        CreateMap<UserDTO, GetUserByIdResponse>()
            .ReverseMap();
        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));

        CreateMap<RegisterRequest, Student>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));

        CreateMap<RegisterRequest, Teacher>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid()));
    }
}
