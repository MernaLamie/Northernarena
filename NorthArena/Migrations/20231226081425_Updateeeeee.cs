using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthArena.Migrations
{
    /// <inheritdoc />
    public partial class Updateeeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SustainabilityQuotesEn",
                table: "Sustainabilities",
                newName: "SustainabilityEnTitle");

            migrationBuilder.RenameColumn(
                name: "SustainabilityQuotesAr",
                table: "Sustainabilities",
                newName: "SustainabilityEnQuotes");

            migrationBuilder.AddColumn<string>(
                name: "SustainabilityArQuotes",
                table: "Sustainabilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SustainabilityArTitle",
                table: "Sustainabilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SustainabilityArQuotes",
                table: "Sustainabilities");

            migrationBuilder.DropColumn(
                name: "SustainabilityArTitle",
                table: "Sustainabilities");

            migrationBuilder.RenameColumn(
                name: "SustainabilityEnTitle",
                table: "Sustainabilities",
                newName: "SustainabilityQuotesEn");

            migrationBuilder.RenameColumn(
                name: "SustainabilityEnQuotes",
                table: "Sustainabilities",
                newName: "SustainabilityQuotesAr");
        }
    }
}
