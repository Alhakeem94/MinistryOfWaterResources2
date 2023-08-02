using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinistryOfWarerResources.Data.Migrations
{
    public partial class Asdasd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpAge = table.Column<int>(type: "int", nullable: false),
                    EmpDep = table.Column<int>(type: "int", nullable: false),
                    EmpSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEmployemnt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpTable_DepTable_EmpDep",
                        column: x => x.EmpDep,
                        principalTable: "DepTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpTable_EmpDep",
                table: "EmpTable",
                column: "EmpDep");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpTable");
        }
    }
}
