using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class Updatedbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 2,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 2, "De anvonturen van Code 2" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 3,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 3, "De anvonturen van Code 3" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 4,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 4, "De anvonturen van Code 4" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 5,
                column: "Titel",
                value: "De anvonturen van Code 5");

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 6,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 2, "De anvonturen van Code 6" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 7,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 3, "De anvonturen van Code 7" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 8,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 4, "De anvonturen van Code 8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 2,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 1, "De anvonturen van Code 1" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 3,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 1, "De anvonturen van Code 1" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 4,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 1, "De anvonturen van Code 1" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 5,
                column: "Titel",
                value: "De anvonturen van Code 1");

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 6,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 1, "De anvonturen van Code 1" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 7,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 1, "De anvonturen van Code 1" });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 8,
                columns: new[] { "AuteurId", "Titel" },
                values: new object[] { 1, "De anvonturen van Code 1" });
        }
    }
}
