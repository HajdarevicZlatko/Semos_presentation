using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Managment.Api.Migrations
{
    public partial class addedRolesTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "27bff9cd-26d4-4f1b-a620-41ce5ce6e09b", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b0b658b-7b58-48a9-9fe7-58e352965d19", "3", "HR", "HR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "917c56da-eef1-4486-a1e6-1e13d0ebe24d", "1", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27bff9cd-26d4-4f1b-a620-41ce5ce6e09b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b0b658b-7b58-48a9-9fe7-58e352965d19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "917c56da-eef1-4486-a1e6-1e13d0ebe24d");

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
    }
}
