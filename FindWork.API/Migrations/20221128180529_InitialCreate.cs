using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindWork.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "interviewCalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HRId = table.Column<string>(type: "TEXT", nullable: true),
                    WorkerId = table.Column<string>(type: "TEXT", nullable: true),
                    Called = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interviewCalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkerId = table.Column<string>(type: "TEXT", nullable: true),
                    VacancyId = table.Column<int>(type: "INTEGER", nullable: true),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    age = table.Column<int>(type: "INTEGER", nullable: false),
                    desireWork = table.Column<string>(type: "TEXT", nullable: true),
                    desireSalary = table.Column<string>(type: "TEXT", nullable: true),
                    employmentDegree = table.Column<string>(type: "TEXT", nullable: true),
                    education = table.Column<string>(type: "TEXT", nullable: true),
                    educationDegree = table.Column<string>(type: "TEXT", nullable: true),
                    graduationYear = table.Column<int>(type: "INTEGER", nullable: false),
                    expirience = table.Column<int>(type: "INTEGER", nullable: false),
                    publishTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    skills = table.Column<string>(type: "TEXT", nullable: true),
                    languages = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    userId = table.Column<string>(type: "TEXT", nullable: true),
                    photoName = table.Column<string>(type: "TEXT", nullable: true),
                    photoSrc = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    secondname = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    salt = table.Column<string>(type: "TEXT", nullable: false),
                    saltedhashedpassword = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    isEmployer = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vacancies",
                columns: table => new
                {
                    vacancyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vacancyname = table.Column<string>(type: "TEXT", nullable: true),
                    company = table.Column<string>(type: "TEXT", nullable: true),
                    category = table.Column<string>(type: "TEXT", nullable: true),
                    publishtime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    salary = table.Column<int>(type: "INTEGER", nullable: false),
                    location = table.Column<string>(type: "TEXT", nullable: true),
                    requires = table.Column<string>(type: "TEXT", nullable: true),
                    offer = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    userId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancies", x => x.vacancyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interviewCalls");

            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "resumes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vacancies");
        }
    }
}
