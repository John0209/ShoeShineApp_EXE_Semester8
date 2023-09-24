using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDbImageStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageComment_CommentStore_CommentStoreId",
                table: "ImageComment");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "ImageComment");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "ImageStoreEntity",
                newName: "ImageStoreId");

            migrationBuilder.AlterColumn<int>(
                name: "CommentStoreId",
                table: "ImageComment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageComment_CommentStore_CommentStoreId",
                table: "ImageComment",
                column: "CommentStoreId",
                principalTable: "CommentStore",
                principalColumn: "CommentStoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageComment_CommentStore_CommentStoreId",
                table: "ImageComment");

            migrationBuilder.RenameColumn(
                name: "ImageStoreId",
                table: "ImageStoreEntity",
                newName: "ImageId");

            migrationBuilder.AlterColumn<int>(
                name: "CommentStoreId",
                table: "ImageComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "ImageComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageComment_CommentStore_CommentStoreId",
                table: "ImageComment",
                column: "CommentStoreId",
                principalTable: "CommentStore",
                principalColumn: "CommentStoreId");
        }
    }
}
