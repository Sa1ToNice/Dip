using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class ev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiveName",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "HiveId",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_HiveId",
                table: "Events",
                column: "HiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Hives_HiveId",
                table: "Events",
                column: "HiveId",
                principalTable: "Hives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Hives_HiveId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_HiveId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "HiveId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "HiveName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
