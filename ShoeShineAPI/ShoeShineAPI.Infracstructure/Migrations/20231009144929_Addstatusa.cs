using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class Addstatusa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "IsServiceStoreStatus",
                table: "ServiceStore",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCategoryStoreStatus",
                table: "CategoryStore",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsServiceStoreStatus",
                table: "ServiceStore");

            migrationBuilder.DropColumn(
                name: "IsCategoryStoreStatus",
                table: "CategoryStore");

            migrationBuilder.RenameColumn(
                name: "StoreEmal",
                table: "Store",
                newName: "StoreEmail");
        }
    }
}
