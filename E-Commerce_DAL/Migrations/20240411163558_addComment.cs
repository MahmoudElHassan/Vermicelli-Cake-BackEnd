using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_DAL.Migrations
{
    /// <inheritdoc />
    public partial class addComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentIntentId",
                table: "Orders",
                newName: "ShipToAddress_Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipToAddress_Comment",
                table: "Orders",
                newName: "PaymentIntentId");
        }
    }
}
