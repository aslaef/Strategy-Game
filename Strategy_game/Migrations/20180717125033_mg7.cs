using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class mg7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elite_Counter",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Horseman_Counter",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "Counter",
                table: "Units",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Counter",
                table: "Units",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Elite_Counter",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Horseman_Counter",
                table: "Units",
                nullable: true);
        }
    }
}
