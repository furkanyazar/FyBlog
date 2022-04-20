using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_move_image_url_from_writer_to_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterImageUrl",
                table: "Writers");

            migrationBuilder.AddColumn<string>(
                name: "UserImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageUrl",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "WriterImageUrl",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
