using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Elite_Counter",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Farm_Counter",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Horseman_Counter",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Buildings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Elite_Counter",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Farm_Counter",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Horseman_Counter",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Buildings");
        }
    }
}
