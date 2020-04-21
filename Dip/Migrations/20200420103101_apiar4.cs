using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class apiar4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiaries_Users_UserId",
                table: "Apiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apiaries",
                table: "Apiaries");

            migrationBuilder.RenameTable(
                name: "Apiaries",
                newName: "Apiary");

            migrationBuilder.RenameIndex(
                name: "IX_Apiaries_UserId",
                table: "Apiary",
                newName: "IX_Apiary_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apiary",
                table: "Apiary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiary_Users_UserId",
                table: "Apiary",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiary_Users_UserId",
                table: "Apiary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apiary",
                table: "Apiary");

            migrationBuilder.RenameTable(
                name: "Apiary",
                newName: "Apiaries");

            migrationBuilder.RenameIndex(
                name: "IX_Apiary_UserId",
                table: "Apiaries",
                newName: "IX_Apiaries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apiaries",
                table: "Apiaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiaries_Users_UserId",
                table: "Apiaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
