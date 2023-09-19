using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class fixRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Store",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_RatingStoresId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "RatingStoresId",
                table: "Store");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "RatingStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RatingStores_StoreId",
                table: "RatingStores",
                column: "StoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Store",
                table: "RatingStores",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Store",
                table: "RatingStores");

            migrationBuilder.DropIndex(
                name: "IX_RatingStores_StoreId",
                table: "RatingStores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "RatingStores");

            migrationBuilder.AddColumn<int>(
                name: "RatingStoresId",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Store_RatingStoresId",
                table: "Store",
                column: "RatingStoresId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Store",
                table: "Store",
                column: "RatingStoresId",
                principalTable: "RatingStores",
                principalColumn: "RatingStoresId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
