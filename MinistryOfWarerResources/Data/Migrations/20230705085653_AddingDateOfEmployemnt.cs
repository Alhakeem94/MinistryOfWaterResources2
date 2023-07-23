using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinistryOfWarerResources.Data.Migrations
{
    public partial class AddingDateOfEmployemnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEmployemnt",
                table: "EmpTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEmployemnt",
                table: "EmpTable");
        }
    }
}
