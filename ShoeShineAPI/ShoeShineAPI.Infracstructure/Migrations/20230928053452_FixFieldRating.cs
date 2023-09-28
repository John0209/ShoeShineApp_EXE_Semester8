using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class FixFieldRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_RatingId",
                table: "Store",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentStore_Rating_RatingId",
                table: "CommentStore",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "RatingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Rating_RatingId",
                table: "Store",
                column: "RatingId",
                principalTable: "Rating",
                principalColumn: "RatingId",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentStore_Rating_RatingId",
                table: "CommentStore");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Rating_RatingId",
                table: "Store");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Store_RatingId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Store");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingStoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingStoresId);
                    table.ForeignKey(
                        name: "FK_Rating_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_StoreId",
                table: "Ratings",
                column: "StoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentStore_Ratings_RatingId",
                table: "CommentStore",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "RatingStoresId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
