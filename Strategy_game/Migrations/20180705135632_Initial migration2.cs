using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class Initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Buildings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CountryId",
                table: "Buildings",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_CountryId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Buildings");
        }
    }
}
