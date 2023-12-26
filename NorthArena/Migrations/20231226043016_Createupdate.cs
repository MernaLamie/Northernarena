using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthArena.Migrations
{
    /// <inheritdoc />
    public partial class Createupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subcategory",
                table: "AboutUs",
                newName: "TitleAr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleAr",
                table: "AboutUs",
                newName: "Subcategory");
        }
    }
}
