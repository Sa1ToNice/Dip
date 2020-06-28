using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class inspect1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frame",
                table: "Inspects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frame",
                table: "Inspects");
        }
    }
}
