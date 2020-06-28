using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class inspect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Force",
                table: "Hives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Mass",
                table: "Hives",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Inspects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Force = table.Column<int>(nullable: false),
                    Mass = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HiveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspects_Hives_HiveId",
                        column: x => x.HiveId,
                        principalTable: "Hives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspects_HiveId",
                table: "Inspects",
                column: "HiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspects");

            migrationBuilder.DropColumn(
                name: "Force",
                table: "Hives");

            migrationBuilder.DropColumn(
                name: "Mass",
                table: "Hives");
        }
    }
}
