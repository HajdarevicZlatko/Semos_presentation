using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Managment.Api.Migrations
{
    public partial class InitialMigrationTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41d45224-5c1c-480c-aa05-d683906b6d9b", "1", "User", "User" },
                    { "97763b64-d3b9-4be3-8bdf-516ed2fa702f", "1", "HR", "HR" },
                    { "a62b35a9-7819-4f22-851e-6ba243eec93e", "1", "Admin", "Admin" },
                    { "ddcb430e-a116-4ce4-ac03-948fea3c04de", "1", "Zlatko", "Zlatko" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41d45224-5c1c-480c-aa05-d683906b6d9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97763b64-d3b9-4be3-8bdf-516ed2fa702f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a62b35a9-7819-4f22-851e-6ba243eec93e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddcb430e-a116-4ce4-ac03-948fea3c04de");

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
    }
}
