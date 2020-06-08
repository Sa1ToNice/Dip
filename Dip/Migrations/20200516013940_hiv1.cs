using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class hiv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatePods",
                table: "Hives",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Heal",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Matka",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plod",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Porod",
                table: "Hives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prois",
                table: "Hives",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePods",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Heal",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Matka",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Plod",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Porod",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Prois",
                table: "Hives");
        }
    }
}
