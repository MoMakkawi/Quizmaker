using System.Reflection;

using FastEndpoints;

using Microsoft.EntityFrameworkCore;

using QuizMaker.Data;
using QuizMaker.Services.Contracts;
using QuizMaker.Services.Repositories;
using FastEndpoints.Swagger;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
             options.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();
builder.Services
    .AddFluentEmail("Quiz.Maker.012@gmail.test")
    .AddSmtpSender(new SmtpClient() { });

//DI
builder.Services.AddScoped(typeof(IAsyncUser), typeof(UserRepository));
builder.Services.AddScoped(typeof(IAsyncStudent), typeof(StudentRepository));
builder.Services.AddScoped(typeof(IAsyncTeacher), typeof(TeacherRepository));

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerDoc();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
    app.UseOpenApi(); 
    app.UseSwaggerUi3(c => c.ConfigureDefaults()); 
}

app.UseHttpsRedirection();
app.UseFastEndpoints();

app.Run();
