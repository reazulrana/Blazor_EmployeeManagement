using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Api.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Account" },
                    { 3, "HR" },
                    { 4, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateofBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 19, 10, 47, 14, 171, DateTimeKind.Local).AddTicks(7829), 1, "Rana@gmail.com", "Reazul Islam", 0, "Rana", "Images/img10.jpg" },
                    { 2, new DateTime(2024, 8, 19, 10, 47, 14, 173, DateTimeKind.Local).AddTicks(5904), 1, "Moushumee@gmail.com", "Moushumee", 1, "Mollika", "Images/img11.jpg" },
                    { 3, new DateTime(2024, 8, 19, 10, 47, 14, 173, DateTimeKind.Local).AddTicks(5937), 1, "Ibrahim@gmail.com", "Ibrahim Rihan", 0, "Ayat", "Images/img12.jpg" },
                    { 4, new DateTime(2024, 8, 19, 10, 47, 14, 173, DateTimeKind.Local).AddTicks(5944), 1, "Milon@gmail.com", "Milon", 0, "Ahmed", "Images/img9.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
