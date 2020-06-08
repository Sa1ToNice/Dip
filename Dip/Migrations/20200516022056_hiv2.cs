using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class hiv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Heal1",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal2",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal3",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal4",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal5",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal6",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal7",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal8",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heal9",
                table: "Hives",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heal1",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal2",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal3",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal4",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal5",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal6",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal7",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal8",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal9",
                table: "Hives");
        }
    }
}
