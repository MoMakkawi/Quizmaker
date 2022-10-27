using Microsoft.EntityFrameworkCore;

using QuizMaker.Identity;
using QuizMaker.Models;

namespace QuizMaker.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions ):base(dbContextOptions)
    {

    }

    public DbSet<Quiz>? Quizzes { get; set; }
    public DbSet<StudentQuiz>? StudentQuizzes { get; set; }
    public DbSet<TeacherQuiz>? TeacherQuizzes { get; set; }
    public DbSet<Teacher>? Teachers { get; set; }
    public DbSet<Student>? Students { get; set; }

}
