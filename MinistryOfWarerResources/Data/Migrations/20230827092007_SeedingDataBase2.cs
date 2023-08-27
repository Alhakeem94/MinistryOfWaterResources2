using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinistryOfWarerResources.Data.Migrations
{
    public partial class SeedingDataBase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "22c8042b-a29a-4930-84ff-ec63fae52c82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09iasdlkamsoidu9a8sdkasmd", "440b21ee-6ec0-4f84-8c28-022690f0ef6b", "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e02d89f4-2db6-4cd5-ab6e-3d3497364559", "97cdd365-2bf7-42ff-93f6-fb6297993485" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09iasdlkamsoidu9a8sdkasmd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole",
                column: "ConcurrencyStamp",
                value: "150cac7c-e242-466f-9e00-fe4835bdd92b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "922ff76b-c46a-4864-b12a-c29ce48a03ae", "48c68039-5134-487d-b96c-35b368865c4f" });
        }
    }
}
