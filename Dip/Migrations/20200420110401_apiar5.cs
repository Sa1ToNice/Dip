using Microsoft.EntityFrameworkCore.Migrations;

namespace Dip.Migrations
{
    public partial class apiar5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiary_Users_UserId",
                table: "Apiary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apiary",
                table: "Apiary");

            migrationBuilder.RenameTable(
                name: "Apiary",
                newName: "Apiaries");

            migrationBuilder.RenameIndex(
                name: "IX_Apiary_UserId",
                table: "Apiaries",
                newName: "IX_Apiaries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apiaries",
                table: "Apiaries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Hives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    ApiaryId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hives_Apiaries_ApiaryId",
                        column: x => x.ApiaryId,
                        principalTable: "Apiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hives_ApiaryId",
                table: "Hives",
                column: "ApiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hives_UserId",
                table: "Hives",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiaries_Users_UserId",
                table: "Apiaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apiaries_Users_UserId",
                table: "Apiaries");

            migrationBuilder.DropTable(
                name: "Hives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apiaries",
                table: "Apiaries");

            migrationBuilder.RenameTable(
                name: "Apiaries",
                newName: "Apiary");

            migrationBuilder.RenameIndex(
                name: "IX_Apiaries_UserId",
                table: "Apiary",
                newName: "IX_Apiary_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apiary",
                table: "Apiary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apiary_Users_UserId",
                table: "Apiary",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
