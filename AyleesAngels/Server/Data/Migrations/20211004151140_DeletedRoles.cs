using Microsoft.EntityFrameworkCore.Migrations;

namespace AyleesAngels.Server.Data.Migrations
{
    public partial class DeletedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f2d0550-4d07-49ba-9457-5f2efc380daf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a7b4d17-7a39-4246-a62a-08123cb77cc8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "804e4530-65be-4a34-a73d-270a97be990a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdccdc7b-4cde-4b7b-a05a-02f38d9f11e1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a7b4d17-7a39-4246-a62a-08123cb77cc8", "9bd1c455-eb17-4bac-a941-65574621e765", "User", "USER" },
                    { "804e4530-65be-4a34-a73d-270a97be990a", "300da634-fa25-47f3-a0e9-8409a564b1b4", "Admin", "ADMIN" },
                    { "fdccdc7b-4cde-4b7b-a05a-02f38d9f11e1", "624b4bda-9fe8-432b-bb7e-960006b0ae1d", "Developer", "DEVELOPER" },
                    { "2f2d0550-4d07-49ba-9457-5f2efc380daf", "0fd4f313-f21d-42b4-aba0-fdce85e10143", "Owner", "OWNER" }
                });
        }
    }
}
