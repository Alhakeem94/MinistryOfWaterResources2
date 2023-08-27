using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinistryOfWarerResources.Data.Migrations
{
    public partial class SeedingDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "oi2eoij-1oqjsdkj-kaslk-OwnerRole", "150cac7c-e242-466f-9e00-fe4835bdd92b", "owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "922ff76b-c46a-4864-b12a-c29ce48a03ae", "MohammedOwner", true, false, null, "MOHAMMEDOWNER", "MOHAMMEDOWNER", "Moh12345_", null, false, "48c68039-5134-487d-b96c-35b368865c4f", false, "MohammedOwner" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "oi2eoij-1oqjsdkj-kaslk-OwnerRole", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "oi2eoij-1oqjsdkj-kaslk-OwnerRole", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "oi2eoij-1oqjsdkj-kaslk-OwnerRole");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");
        }
    }
}
