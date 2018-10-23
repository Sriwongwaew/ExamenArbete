using Microsoft.EntityFrameworkCore.Migrations;

namespace Mood2.Migrations
{
    public partial class playlist11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_EmotionData_EmotionDataId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_EmotionDataId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "EmotionDataId",
                table: "History");

            migrationBuilder.AddColumn<string>(
                name: "Emotion",
                table: "History",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Playlist",
                table: "History",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Playlist",
                table: "History");

            migrationBuilder.AddColumn<int>(
                name: "EmotionDataId",
                table: "History",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_History_EmotionDataId",
                table: "History",
                column: "EmotionDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_EmotionData_EmotionDataId",
                table: "History",
                column: "EmotionDataId",
                principalTable: "EmotionData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
