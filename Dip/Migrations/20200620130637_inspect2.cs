using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class inspect2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePods",
                table: "Inspects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Matka",
                table: "Inspects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Plod",
                table: "Inspects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePods",
                table: "Inspects");

            migrationBuilder.DropColumn(
                name: "Matka",
                table: "Inspects");

            migrationBuilder.DropColumn(
                name: "Plod",
                table: "Inspects");
        }
    }
}
