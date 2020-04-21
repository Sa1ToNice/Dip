using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class apiar6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hives_Users_UserId",
                table: "Hives");

            migrationBuilder.DropIndex(
                name: "IX_Hives_UserId",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hives");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hives",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hives_UserId",
                table: "Hives",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hives_Users_UserId",
                table: "Hives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
