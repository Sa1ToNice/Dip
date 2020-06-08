using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class hiv7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hlen",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Wlen",
                table: "Hives");

            migrationBuilder.AddColumn<int>(
                name: "Frame",
                table: "Hives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hframe",
                table: "Hives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wframe",
                table: "Hives",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frame",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Hframe",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Wframe",
                table: "Hives");

            migrationBuilder.AddColumn<string>(
                name: "Hlen",
                table: "Hives",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wlen",
                table: "Hives",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
