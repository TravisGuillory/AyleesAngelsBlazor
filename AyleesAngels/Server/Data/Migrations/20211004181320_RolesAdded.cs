using Microsoft.EntityFrameworkCore.Migrations;

namespace AyleesAngels.Server.Data.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d04deacc-93a5-4de1-ba03-1bfdb6ad7a31", "4ddd96e9-c18f-423a-afa5-90461086174c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a5fdf6c-c98a-4792-b6e4-671c4f7115f2", "17e7e662-61ca-45f3-8c7d-fbf68e584e31", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a5fdf6c-c98a-4792-b6e4-671c4f7115f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d04deacc-93a5-4de1-ba03-1bfdb6ad7a31");
        }
    }
}
