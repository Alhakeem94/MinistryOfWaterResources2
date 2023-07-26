using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinistryOfWarerResources.Data.Migrations
{
    public partial class AddingFilePath2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpImagePath",
                table: "EmpTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpImagePath",
                table: "EmpTable");
        }
    }
}
