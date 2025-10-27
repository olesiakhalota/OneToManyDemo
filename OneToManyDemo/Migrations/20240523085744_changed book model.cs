using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyDemo.Migrations
{
    /// <inheritdoc />
    public partial class changedbookmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Boeks",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BindingType",
                table: "Boeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaiable",
                table: "Boeks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBestseller",
                table: "Boeks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewRelease",
                table: "Boeks",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 1,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 2,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 3,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 4,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 5,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 6,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 7,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });

            migrationBuilder.UpdateData(
                table: "Boeks",
                keyColumn: "BoekId",
                keyValue: 8,
                columns: new[] { "BindingType", "IsAvaiable", "IsBestseller", "IsNewRelease" },
                values: new object[] { 0, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BindingType",
                table: "Boeks");

            migrationBuilder.DropColumn(
                name: "IsAvaiable",
                table: "Boeks");

            migrationBuilder.DropColumn(
                name: "IsBestseller",
                table: "Boeks");

            migrationBuilder.DropColumn(
                name: "IsNewRelease",
                table: "Boeks");

            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Boeks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
