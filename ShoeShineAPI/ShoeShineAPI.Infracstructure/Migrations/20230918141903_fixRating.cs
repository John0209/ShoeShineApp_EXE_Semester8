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
                table: "StoreEntity");

            migrationBuilder.DropIndex(
                name: "IX_Store_RatingStoresId",
                table: "StoreEntity");

            migrationBuilder.DropColumn(
                name: "RatingStoresId",
                table: "StoreEntity");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "RatingStoresEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RatingStores_StoreId",
                table: "RatingStoresEntity",
                column: "StoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Store",
                table: "RatingStoresEntity",
                column: "StoreId",
                principalTable: "StoreEntity",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Store",
                table: "RatingStoresEntity");

            migrationBuilder.DropIndex(
                name: "IX_RatingStores_StoreId",
                table: "RatingStoresEntity");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "RatingStoresEntity");

            migrationBuilder.AddColumn<int>(
                name: "RatingStoresId",
                table: "StoreEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Store_RatingStoresId",
                table: "StoreEntity",
                column: "RatingStoresId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Store",
                table: "StoreEntity",
                column: "RatingStoresId",
                principalTable: "RatingStoresEntity",
                principalColumn: "RatingStoresId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
