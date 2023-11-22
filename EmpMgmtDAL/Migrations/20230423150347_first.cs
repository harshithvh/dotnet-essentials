using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpMgmtDAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TA = table.Column<byte>(type: "tinyint", nullable: false),
                    HRA = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false),
                    DOJ = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeptId = table.Column<byte>(type: "tinyint", nullable: false),
                    GradeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Dept1" },
                    { (byte)2, "Dept2" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Basic", "HRA", "Name", "TA" },
                values: new object[,]
                {
                    { (byte)1, 15000m, (byte)20, "E1", (byte)12 },
                    { (byte)2, 12000m, (byte)15, "E2", (byte)10 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "DOB", "DOJ", "DeptId", "Email", "Gender", "GradeId", "Name", "Password", "Status" },
                values: new object[] { (byte)1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)1, "uemp@mail.com", "M", (byte)1, "UEmp", "pass123", (byte)1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmpId", "DOB", "DOJ", "DeptId", "Email", "Gender", "GradeId", "Name", "Password", "Status" },
                values: new object[] { (byte)2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, (byte)2, "0emp@mail.com", "F", (byte)2, "OEmp", "pass123", (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptId",
                table: "Employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GradeId",
                table: "Employees",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
