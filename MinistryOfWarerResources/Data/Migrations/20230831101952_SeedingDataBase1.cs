using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinistryOfWarerResources.Data.Migrations
{
    public partial class SeedingDataBase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09iasdlkamsoidu9a8sdkasmd",
                column: "ConcurrencyStamp",
                value: "f4ea2a9a-97ed-43dd-9797-4070db77d65b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "5a1db899-44d5-4f5b-8e9b-da62400b0bb1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09iasdlkamsoidu9a8sdkapiasjdm", "4daf1cf2-6d0d-4d61-8b96-e555e75636fe", "regulator", "REGULATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11f8b45b-b925-4719-8e40-c4be4c723b82", "93f905ac-0ed0-45f0-b3aa-105f8a74ffd7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09iasdlkamsoidu9a8sdkapiasjdm");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09iasdlkamsoidu9a8sdkasmd",
                column: "ConcurrencyStamp",
                value: "440b21ee-6ec0-4f84-8c28-022690f0ef6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "22c8042b-a29a-4930-84ff-ec63fae52c82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e02d89f4-2db6-4cd5-ab6e-3d3497364559", "97cdd365-2bf7-42ff-93f6-fb6297993485" });
        }
    }
}
