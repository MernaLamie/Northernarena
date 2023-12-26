using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthArena.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Reservations",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Reservations",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ChairNo",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FloorORClass",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FloorORClass",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Reservations",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Reservations",
                newName: "NameEn");

            migrationBuilder.AlterColumn<string>(
                name: "ChairNo",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
