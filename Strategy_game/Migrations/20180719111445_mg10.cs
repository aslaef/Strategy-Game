using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class mg10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Platoons_PlatoonTagPlatoonId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_PlatoonTagPlatoonId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PlatoonTagPlatoonId",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "ArchersUnitId",
                table: "Platoons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorsemansUnitId",
                table: "Platoons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoldiersUnitId",
                table: "Platoons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platoons_ArchersUnitId",
                table: "Platoons",
                column: "ArchersUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Platoons_HorsemansUnitId",
                table: "Platoons",
                column: "HorsemansUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Platoons_SoldiersUnitId",
                table: "Platoons",
                column: "SoldiersUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platoons_Units_ArchersUnitId",
                table: "Platoons",
                column: "ArchersUnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platoons_Units_HorsemansUnitId",
                table: "Platoons",
                column: "HorsemansUnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platoons_Units_SoldiersUnitId",
                table: "Platoons",
                column: "SoldiersUnitId",
                principalTable: "Units",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platoons_Units_ArchersUnitId",
                table: "Platoons");

            migrationBuilder.DropForeignKey(
                name: "FK_Platoons_Units_HorsemansUnitId",
                table: "Platoons");

            migrationBuilder.DropForeignKey(
                name: "FK_Platoons_Units_SoldiersUnitId",
                table: "Platoons");

            migrationBuilder.DropIndex(
                name: "IX_Platoons_ArchersUnitId",
                table: "Platoons");

            migrationBuilder.DropIndex(
                name: "IX_Platoons_HorsemansUnitId",
                table: "Platoons");

            migrationBuilder.DropIndex(
                name: "IX_Platoons_SoldiersUnitId",
                table: "Platoons");

            migrationBuilder.DropColumn(
                name: "ArchersUnitId",
                table: "Platoons");

            migrationBuilder.DropColumn(
                name: "HorsemansUnitId",
                table: "Platoons");

            migrationBuilder.DropColumn(
                name: "SoldiersUnitId",
                table: "Platoons");

            migrationBuilder.AddColumn<int>(
                name: "PlatoonTagPlatoonId",
                table: "Units",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_PlatoonTagPlatoonId",
                table: "Units",
                column: "PlatoonTagPlatoonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Platoons_PlatoonTagPlatoonId",
                table: "Units",
                column: "PlatoonTagPlatoonId",
                principalTable: "Platoons",
                principalColumn: "PlatoonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
