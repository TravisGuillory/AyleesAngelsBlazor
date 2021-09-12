using Microsoft.EntityFrameworkCore.Migrations;

namespace AyleesAngels.Server.Migrations
{
    public partial class AddImageToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostImage",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostImage",
                table: "BlogPosts");
        }
    }
}
