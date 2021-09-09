using Microsoft.EntityFrameworkCore.Migrations;

namespace AyleesAngels.Server.Migrations.OfficerDb
{
    public partial class CorrectedOfficersTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Officer",
                table: "Officer");

            migrationBuilder.RenameTable(
                name: "Officer",
                newName: "Officers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Officers",
                table: "Officers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Officers",
                table: "Officers");

            migrationBuilder.RenameTable(
                name: "Officers",
                newName: "Officer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Officer",
                table: "Officer",
                column: "Id");
        }
    }
}
