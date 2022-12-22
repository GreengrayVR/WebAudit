using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Data.Migrations
{
    public partial class ChangeCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_URLS_Checks_CheckId",
                table: "URLS");

            migrationBuilder.DropIndex(
                name: "IX_URLS_CheckId",
                table: "URLS");

            migrationBuilder.DropColumn(
                name: "CheckId",
                table: "URLS");

            migrationBuilder.AddColumn<int>(
                name: "UrlId",
                table: "Checks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_UrlId",
                table: "Checks",
                column: "UrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checks_URLS_UrlId",
                table: "Checks",
                column: "UrlId",
                principalTable: "URLS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checks_URLS_UrlId",
                table: "Checks");

            migrationBuilder.DropIndex(
                name: "IX_Checks_UrlId",
                table: "Checks");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "Checks");

            migrationBuilder.AddColumn<int>(
                name: "CheckId",
                table: "URLS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_URLS_CheckId",
                table: "URLS",
                column: "CheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_URLS_Checks_CheckId",
                table: "URLS",
                column: "CheckId",
                principalTable: "Checks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
