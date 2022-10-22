using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesss.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_UserId",
                table: "FeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FeedBacks");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "FeedBacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "FeedBacks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_UserId",
                table: "FeedBacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
