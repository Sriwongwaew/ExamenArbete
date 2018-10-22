using Microsoft.EntityFrameworkCore.Migrations;

namespace Mood2.Migrations
{
    public partial class playlist6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Em_EmId",
                table: "History");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Em",
                table: "Em");

            migrationBuilder.RenameTable(
                name: "Em",
                newName: "Emotion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emotion",
                table: "Emotion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Emotion_EmId",
                table: "History",
                column: "EmId",
                principalTable: "Emotion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Emotion_EmId",
                table: "History");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emotion",
                table: "Emotion");

            migrationBuilder.RenameTable(
                name: "Emotion",
                newName: "Em");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Em",
                table: "Em",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Em_EmId",
                table: "History",
                column: "EmId",
                principalTable: "Em",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
