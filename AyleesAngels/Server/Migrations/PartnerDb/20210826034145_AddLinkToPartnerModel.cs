using Microsoft.EntityFrameworkCore.Migrations;

namespace AyleesAngels.Server.Migrations.PartnerDb
{
    public partial class AddLinkToPartnerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Partners");
        }
    }
}
