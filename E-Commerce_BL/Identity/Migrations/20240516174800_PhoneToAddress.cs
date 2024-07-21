using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_BL.Migrations
{
    /// <inheritdoc />
    public partial class PhoneToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Address");
        }
    }
}
