using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Comment",
                table: "CommentStore");

            migrationBuilder.DropIndex(
                name: "IX_CommentStore_RatingCommentId",
                table: "CommentStore");

            migrationBuilder.AlterColumn<string>(
                name: "UserGender",
                table: "User",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "StoreEmal",
                table: "Store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StorePhone",
                table: "Store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IsOrderStatus",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommentStore_RatingCommentId",
                table: "CommentStore",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentStore_RatingComment_RatingCommentId",
                table: "CommentStore",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "RatingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentStore_RatingComment_RatingCommentId",
                table: "CommentStore");

            migrationBuilder.DropIndex(
                name: "IX_CommentStore_RatingCommentId",
                table: "CommentStore");

            migrationBuilder.DropColumn(
                name: "StoreEmal",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "StorePhone",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "IsOrderStatus",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "UserGender",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.CreateIndex(
                name: "IX_CommentStore_RatingCommentId",
                table: "CommentStore",
                column: "RatingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Comment",
                table: "CommentStore",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "RatingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
