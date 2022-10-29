using Microsoft.EntityFrameworkCore.Migrations;

using QuizMaker.Identity;

#nullable disable

namespace QuizMaker.Migrations
{
    public partial class SeedFirst2Teachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Teachers",
            columns: new[] { "Id", "FirstName", "LastName", "Email","Password","Role" },
            values: new object[] { "fa485500-3f43-4756-a45e-a9c4fa475789", "Rame", "Shouka", "RameTeacher@gmail.com","20002000",0 });

            migrationBuilder.InsertData(
            table: "Teachers",
            columns: new[] { "Id", "FirstName", "LastName", "Email", "Password", "Role" },
            values: new object[] { "09889c40-5e95-4522-99f7-0bfab29fbfea", "Ammar", "Najar", "AmmarTeacher@gmail.com", "19991999", 0 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Teachers] WHERE Id = 'fa485500-3f43-4756-a45e-a9c4fa475789'");
            migrationBuilder.Sql("DELETE FROM [Teachers] WHERE Id = '09889c40-5e95-4522-99f7-0bfab29fbfea'");
        }
    }
}
