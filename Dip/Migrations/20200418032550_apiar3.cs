using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class apiar3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "desc",
                table: "Apiaries");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Apiaries");

            migrationBuilder.AddColumn<string>(
                name: "map",
                table: "Apiaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "map",
                table: "Apiaries");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Info",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "Apiaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Apiaries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
