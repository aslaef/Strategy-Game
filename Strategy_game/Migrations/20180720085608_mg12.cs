using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class mg12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Intent",
                table: "Platoons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intent",
                table: "Platoons");
        }
    }
}
