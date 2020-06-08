using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class hiv6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hlen",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wlen",
                table: "Hives",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hlen",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Wlen",
                table: "Hives");
        }
    }
}
