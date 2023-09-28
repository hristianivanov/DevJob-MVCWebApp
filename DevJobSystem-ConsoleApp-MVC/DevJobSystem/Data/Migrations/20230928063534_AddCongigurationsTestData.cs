using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevJobSystem.Data.Migrations
{
    public partial class AddCongigurationsTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "AvgSalary", "Name", "ProgrammersCount" },
                values: new object[,]
                {
                    { new Guid("3d2e8998-4d57-4541-864e-fd0bf99b7ed3"), "456 Elm Avenue, Town", 85000.00m, "SoftTech Solutions", 30 },
                    { new Guid("6edd17b7-8291-4fda-a343-de3ecba2a4e2"), "123 Main Street, City", 95000.00m, "TechCo Inc.", 50 },
                    { new Guid("a0ee66ad-cafe-4a97-afc7-3dea62a3a256"), "222 Cedar Street, Metro", 92000.00m, "UX Innovations", 20 },
                    { new Guid("a286dc6f-4293-470c-9e64-58c6d029a8b3"), "101 Pine Lane, Suburb", 80000.00m, "WebDesigners Ltd.", 40 },
                    { new Guid("e5d9fa8d-3163-456e-be6b-07a2e43af378"), "789 Oak Road, Village", 90000.00m, "DataAnalytics Corp.", 25 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description", "ExpireDate", "PublishedDate", "Requirements" },
                values: new object[,]
                {
                    { 1, "Full Stack Developer", new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience with JavaScript, React, and Node.js" },
                    { 2, "Software Engineer", new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proficiency in Python and Django" },
                    { 3, "Data Analyst", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strong analytical skills and knowledge of SQL" },
                    { 4, "Frontend Developer", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Familiarity with HTML, CSS, and JavaScript frameworks" },
                    { 5, "UI/UX Designer", new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creative design skills and proficiency in design tools" }
                });

            migrationBuilder.InsertData(
                table: "Programmers",
                columns: new[] { "Id", "Experience", "FirstName", "HireDate", "LastName", "Salary", "Skill" },
                values: new object[,]
                {
                    { new Guid("006a5812-e531-4c6a-815a-215e61595cec"), 3, "Alice", new DateTime(2022, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 70000.00m, "JavaScript, React" },
                    { new Guid("16b08a53-8c7f-4112-b109-7ef7c0a919b4"), 2, "Emily", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", 65000.00m, "Python, Django" },
                    { new Guid("db412b5c-100f-49f3-8ff9-963caee38c2a"), 7, "Michael", new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", 90000.00m, "Java, Spring Boot" },
                    { new Guid("f1421d2a-808f-4ce2-ad21-9ecd86150483"), 5, "John", new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", 80000.00m, "C#, ASP.NET Core" },
                    { new Guid("f92eef01-c91b-4be6-975d-80e03edfbd5b"), 6, "Robert", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garcia", 85000.00m, "Ruby on Rails" }
                });

            migrationBuilder.InsertData(
                table: "CompaniesProgrammers",
                columns: new[] { "CompanyId", "ProgrammerId" },
                values: new object[] { new Guid("3d2e8998-4d57-4541-864e-fd0bf99b7ed3"), new Guid("16b08a53-8c7f-4112-b109-7ef7c0a919b4") });

            migrationBuilder.InsertData(
                table: "CompaniesProgrammers",
                columns: new[] { "CompanyId", "ProgrammerId" },
                values: new object[] { new Guid("6edd17b7-8291-4fda-a343-de3ecba2a4e2"), new Guid("f92eef01-c91b-4be6-975d-80e03edfbd5b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a0ee66ad-cafe-4a97-afc7-3dea62a3a256"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a286dc6f-4293-470c-9e64-58c6d029a8b3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e5d9fa8d-3163-456e-be6b-07a2e43af378"));

            migrationBuilder.DeleteData(
                table: "CompaniesProgrammers",
                keyColumns: new[] { "CompanyId", "ProgrammerId" },
                keyValues: new object[] { new Guid("3d2e8998-4d57-4541-864e-fd0bf99b7ed3"), new Guid("16b08a53-8c7f-4112-b109-7ef7c0a919b4") });

            migrationBuilder.DeleteData(
                table: "CompaniesProgrammers",
                keyColumns: new[] { "CompanyId", "ProgrammerId" },
                keyValues: new object[] { new Guid("6edd17b7-8291-4fda-a343-de3ecba2a4e2"), new Guid("f92eef01-c91b-4be6-975d-80e03edfbd5b") });

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: new Guid("006a5812-e531-4c6a-815a-215e61595cec"));

            migrationBuilder.DeleteData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: new Guid("db412b5c-100f-49f3-8ff9-963caee38c2a"));

            migrationBuilder.DeleteData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: new Guid("f1421d2a-808f-4ce2-ad21-9ecd86150483"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("3d2e8998-4d57-4541-864e-fd0bf99b7ed3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6edd17b7-8291-4fda-a343-de3ecba2a4e2"));

            migrationBuilder.DeleteData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: new Guid("16b08a53-8c7f-4112-b109-7ef7c0a919b4"));

            migrationBuilder.DeleteData(
                table: "Programmers",
                keyColumn: "Id",
                keyValue: new Guid("f92eef01-c91b-4be6-975d-80e03edfbd5b"));
        }
    }
}
