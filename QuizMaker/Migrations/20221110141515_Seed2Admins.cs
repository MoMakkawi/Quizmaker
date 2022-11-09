using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizMaker.Migrations
{
    public partial class Seed2Admins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Admins",
            columns: new[] { "Id", "FirstName", "LastName", "Email", "Password", "Role" },
            values: new object[] { "fa485500-3f43-4756-a45e-a9c4fa475789", "Rame", "Shouka", "RameAdmin@gmail.com", "20002000", 0 });

            migrationBuilder.InsertData(
            table: "Admins",
            columns: new[] { "Id", "FirstName", "LastName", "Email", "Password", "Role" },
            values: new object[] { "09889c40-5e95-4522-99f7-0bfab29fbfea", "Ammar", "Najar", "AmmarAdmin@gmail.com", "19991999", 0 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Admins] WHERE Id = 'fa485500-3f43-4756-a45e-a9c4fa475789'");
            migrationBuilder.Sql("DELETE FROM [Admins] WHERE Id = '09889c40-5e95-4522-99f7-0bfab29fbfea'");
        }
    }
}
