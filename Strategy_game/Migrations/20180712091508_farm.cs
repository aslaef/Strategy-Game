using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class farm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Farm_Counter",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PotatoesPerRound",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "Farm_Counter",
                table: "Buildings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Buildings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotatoesPerRound",
                table: "Buildings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Farm_Counter",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "PotatoesPerRound",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "Farm_Counter",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PotatoesPerRound",
                table: "Units",
                nullable: true);
        }
    }
}
