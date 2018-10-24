using Microsoft.EntityFrameworkCore.Migrations;

namespace Mood2.Migrations
{
    public partial class kek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Playlist",
                table: "History",
                newName: "PlaylistName");

            migrationBuilder.AddColumn<string>(
                name: "PlaylistLink",
                table: "History",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaylistLink",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "PlaylistName",
                table: "History",
                newName: "Playlist");
        }
    }
}
