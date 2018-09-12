using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Buildings",
                newName: "OwnerCountryCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_CountryId",
                table: "Buildings",
                newName: "IX_Buildings_OwnerCountryCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Countries_OwnerCountryCountryId",
                table: "Buildings",
                column: "OwnerCountryCountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Countries_OwnerCountryCountryId",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "OwnerCountryCountryId",
                table: "Buildings",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_OwnerCountryCountryId",
                table: "Buildings",
                newName: "IX_Buildings_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Countries_CountryId",
                table: "Buildings",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
