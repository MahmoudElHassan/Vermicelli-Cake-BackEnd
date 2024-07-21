using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_DAL.Migrations
{
    /// <inheritdoc />
    public partial class editProductFlavorAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Flavors_FlavorId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Flavors");

            migrationBuilder.DropIndex(
                name: "IX_Products_FlavorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FlavorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShipToAddress_City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DeliveryMethods");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_ZipCode",
                table: "Orders",
                newName: "ShipToAddress_Flat");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_State",
                table: "Orders",
                newName: "ShipToAddress_Building");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "DeliveryMethods",
                newName: "Area");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipToAddress_Flat",
                table: "Orders",
                newName: "ShipToAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "ShipToAddress_Building",
                table: "Orders",
                newName: "ShipToAddress_State");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "DeliveryMethods",
                newName: "ShortName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FlavorId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShipToAddress_City",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DeliveryMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FlavorId",
                table: "Products",
                column: "FlavorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Flavors_FlavorId",
                table: "Products",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
