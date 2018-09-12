using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Strategy_game.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tractor = table.Column<bool>(nullable: false),
                    Combine = table.Column<bool>(nullable: false),
                    Wall = table.Column<bool>(nullable: false),
                    Commander = table.Column<bool>(nullable: false),
                    Tactican = table.Column<bool>(nullable: false),
                    Alchemy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoundNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Platoons",
                columns: table => new
                {
                    PlatoonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platoons", x => x.PlatoonId);
                    table.ForeignKey(
                        name: "FK_Platoons_Countries_OwnerCountryId",
                        column: x => x.OwnerCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<int>(nullable: false),
                    OwnedCountryCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Countries_OwnedCountryCountryId",
                        column: x => x.OwnedCountryCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DefenderPosition = table.Column<bool>(nullable: false),
                    Atk = table.Column<int>(nullable: false),
                    Def = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Food = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    OwnerCountryCountryId = table.Column<int>(nullable: true),
                    PlatoonTagPlatoonId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Population = table.Column<int>(nullable: true),
                    PotatoesPerRound = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Units_Countries_OwnerCountryCountryId",
                        column: x => x.OwnerCountryCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Platoons_PlatoonTagPlatoonId",
                        column: x => x.PlatoonTagPlatoonId,
                        principalTable: "Platoons",
                        principalColumn: "PlatoonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Platoons_OwnerCountryId",
                table: "Platoons",
                column: "OwnerCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_OwnerCountryCountryId",
                table: "Units",
                column: "OwnerCountryCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_PlatoonTagPlatoonId",
                table: "Units",
                column: "PlatoonTagPlatoonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OwnedCountryCountryId",
                table: "Users",
                column: "OwnedCountryCountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Platoons");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
