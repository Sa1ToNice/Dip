using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class dbfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Info",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "Info",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Info",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Apiaries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "map",
                table: "Apiaries",
                newName: "Map");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Apiaries",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Info",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Info",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Info",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Apiaries",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Map",
                table: "Apiaries",
                newName: "map");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Apiaries",
                newName: "id");
        }
    }
}
