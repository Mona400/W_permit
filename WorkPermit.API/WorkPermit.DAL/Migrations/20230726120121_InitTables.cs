using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkPermit.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusModels",
                columns: table => new
                {
                    NewStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "WorkPermitRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "New")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPermitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPermitRequests_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkPermitRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPermitRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_WorkPermitRequests_WorkPermitRequestId",
                        column: x => x.WorkPermitRequestId,
                        principalTable: "WorkPermitRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPermitRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_WorkPermitRequests_WorkPermitRequestId",
                        column: x => x.WorkPermitRequestId,
                        principalTable: "WorkPermitRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IS" },
                    { 2, "CS" },
                    { 3, "DS" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "Mona", "Engineer" },
                    { 2, "Hossam", "Doctor" },
                    { 3, "Ali", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "WorkPermitRequests",
                columns: new[] { "Id", "DepartmentId", "EmployeeId", "EndDate", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 1, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "New" },
                    { 2, 2, 2, new DateTime(2022, 1, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), "New" },
                    { 3, 3, 3, new DateTime(2022, 1, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "New" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "WorkPermitRequestId" },
                values: new object[,]
                {
                    { 1, "Activity 1", 1 },
                    { 2, "Activity 2", 1 },
                    { 3, "Activity 3", 2 },
                    { 4, "Activity 4", 3 },
                    { 5, "Activity 5", 1 },
                    { 6, "Activity 6", 1 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name", "WorkPermitRequestId" },
                values: new object[,]
                {
                    { 1, "Equipment 1", 1 },
                    { 2, "Equipment 2", 2 },
                    { 3, "Equipment 3", 1 },
                    { 4, "Equipment 4", 1 },
                    { 5, "Equipment 5", 3 },
                    { 6, "Equipment 6", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_WorkPermitRequestId",
                table: "Activities",
                column: "WorkPermitRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_WorkPermitRequestId",
                table: "Equipment",
                column: "WorkPermitRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRequests_DepartmentId",
                table: "WorkPermitRequests",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPermitRequests_EmployeeId",
                table: "WorkPermitRequests",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "StatusModels");

            migrationBuilder.DropTable(
                name: "WorkPermitRequests");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
