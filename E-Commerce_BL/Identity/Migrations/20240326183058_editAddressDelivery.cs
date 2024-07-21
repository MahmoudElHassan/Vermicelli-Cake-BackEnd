using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_BL.Migrations
{
    /// <inheritdoc />
    public partial class editAddressDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Address",
                newName: "Flat");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Address",
                newName: "Building");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Flat",
                table: "Address",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "Building",
                table: "Address",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
