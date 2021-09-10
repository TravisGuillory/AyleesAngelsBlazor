using Microsoft.EntityFrameworkCore.Migrations;

namespace AyleesAngels.Server.Migrations.OfficerDb
{
    public partial class AddOrderNumberToOfficer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Officers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Officers");
        }
    }
}
