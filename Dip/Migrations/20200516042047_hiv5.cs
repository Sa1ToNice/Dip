using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class hiv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Apiaries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Apiaries");
        }
    }
}
