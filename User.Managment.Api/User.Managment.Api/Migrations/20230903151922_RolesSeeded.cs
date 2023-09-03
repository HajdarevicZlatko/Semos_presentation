using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Managment.Api.Migrations
{
    public partial class RolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3efc5aaf-fcf0-4cd0-9d11-0f5e0c70ece8", "1", "HR", "HR" },
                    { "46173859-9463-499f-9713-986cae915ce4", "1", "Admin", "Admin" },
                    { "c656f58a-3cb6-4194-aee3-c9c49c201eb4", "1", "Zlatko", "Zlatko" },
                    { "f0bcb20b-dfc3-4c09-a3d0-02b030c5dece", "1", "User", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3efc5aaf-fcf0-4cd0-9d11-0f5e0c70ece8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46173859-9463-499f-9713-986cae915ce4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c656f58a-3cb6-4194-aee3-c9c49c201eb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0bcb20b-dfc3-4c09-a3d0-02b030c5dece");
        }
    }
}
