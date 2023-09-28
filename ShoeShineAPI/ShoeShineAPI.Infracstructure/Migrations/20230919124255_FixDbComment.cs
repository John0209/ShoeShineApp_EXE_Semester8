using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDbComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageComment_Comment_CommentId",
                table: "ImageComment");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_ImageComment_CommentId",
                table: "ImageComment");

            migrationBuilder.AddColumn<int>(
                name: "CommentStoreId",
                table: "ImageComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommentStore",
                columns: table => new
                {
                    CommentStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    RatingCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentStore", x => x.CommentStoreId);
                    table.ForeignKey(
                        name: "FK_CommentStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentStore_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Comment",
                        column: x => x.RatingCommentId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageComment_CommentStoreId",
                table: "ImageComment",
                column: "CommentStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentStore_RatingCommentId",
                table: "CommentStore",
                column: "RatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentStore_StoreId",
                table: "CommentStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentStore_UserId",
                table: "CommentStore",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageComment_CommentStore_CommentStoreId",
                table: "ImageComment",
                column: "CommentStoreId",
                principalTable: "CommentStore",
                principalColumn: "CommentStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageComment_CommentStore_CommentStoreId",
                table: "ImageComment");

            migrationBuilder.DropTable(
                name: "CommentStore");

            migrationBuilder.DropIndex(
                name: "IX_ImageComment_CommentStoreId",
                table: "ImageComment");

            migrationBuilder.DropColumn(
                name: "CommentStoreId",
                table: "ImageComment");

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RatingCommentId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductEntity",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Comment",
                        column: x => x.RatingCommentId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageComment_CommentId",
                table: "ImageComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RatingCommentId",
                table: "Comment",
                column: "RatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StoreId",
                table: "Comment",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageComment_Comment_CommentId",
                table: "ImageComment",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
