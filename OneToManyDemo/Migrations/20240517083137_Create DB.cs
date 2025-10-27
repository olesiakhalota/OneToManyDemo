using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoekenViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeselecteerdeAuteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoekenViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BoekenViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.AuteurId);
                    table.ForeignKey(
                        name: "FK_Auteurs_BoekenViewModel_BoekenViewModelId",
                        column: x => x.BoekenViewModelId,
                        principalTable: "BoekenViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BoekAuteurViewModel",
                columns: table => new
                {
                    BoekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuteurNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoekenViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoekAuteurViewModel", x => x.BoekId);
                    table.ForeignKey(
                        name: "FK_BoekAuteurViewModel_BoekenViewModel_BoekenViewModelId",
                        column: x => x.BoekenViewModelId,
                        principalTable: "BoekenViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Boeks",
                columns: table => new
                {
                    BoekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeks", x => x.BoekId);
                    table.ForeignKey(
                        name: "FK_Boeks_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "AuteurId");
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "AuteurId", "BoekenViewModelId", "Naam" },
                values: new object[,]
                {
                    { 1, null, "J.K. Rolling" },
                    { 2, null, "Stephen King" },
                    { 3, null, "J.R.R. Tolkien" },
                    { 4, null, "Dan Brown" }
                });

            migrationBuilder.InsertData(
                table: "Boeks",
                columns: new[] { "BoekId", "AuteurId", "Titel" },
                values: new object[,]
                {
                    { 1, 1, "De anvonturen van Code 1" },
                    { 2, 1, "De anvonturen van Code 1" },
                    { 3, 1, "De anvonturen van Code 1" },
                    { 4, 1, "De anvonturen van Code 1" },
                    { 5, 1, "De anvonturen van Code 1" },
                    { 6, 1, "De anvonturen van Code 1" },
                    { 7, 1, "De anvonturen van Code 1" },
                    { 8, 1, "De anvonturen van Code 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auteurs_BoekenViewModelId",
                table: "Auteurs",
                column: "BoekenViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BoekAuteurViewModel_BoekenViewModelId",
                table: "BoekAuteurViewModel",
                column: "BoekenViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeks_AuteurId",
                table: "Boeks",
                column: "AuteurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoekAuteurViewModel");

            migrationBuilder.DropTable(
                name: "Boeks");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "BoekenViewModel");
        }
    }
}
