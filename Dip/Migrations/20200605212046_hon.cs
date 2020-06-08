using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class hon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Apiaries_ApiaryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApiaryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ApiaryId",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "Honey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Get = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HiveId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Honey_Hives_HiveId",
                        column: x => x.HiveId,
                        principalTable: "Hives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Honey_HiveId",
                table: "Honey",
                column: "HiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Honey");

            migrationBuilder.AddColumn<int>(
                name: "ApiaryId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApiaryId",
                table: "Events",
                column: "ApiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Apiaries_ApiaryId",
                table: "Events",
                column: "ApiaryId",
                principalTable: "Apiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
