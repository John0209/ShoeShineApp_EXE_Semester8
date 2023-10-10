using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "UserRegisterDate",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StoreRegisterDate",
                table: "Store",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingCategory_Category_CategoryId",
                table: "BookingCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryStore_Category_CategoryId",
                table: "CategoryStore");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserRegisterDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StoreRegisterDate",
                table: "Store");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "CategoryIdArray");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryIdArray");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryStore",
                newName: "CategoryIdArray");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryStore_CategoryId",
                table: "CategoryStore",
                newName: "IX_CategoryStore_CategoryIdArray");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "CategoryIdArray");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "BookingCategory",
                newName: "CategoryIdArray");

            migrationBuilder.RenameIndex(
                name: "IX_BookingCategory_CategoryId",
                table: "BookingCategory",
                newName: "IX_BookingCategory_CategoryIdArray");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingCategory_Category_CategoryIdArray",
                table: "BookingCategory",
                column: "CategoryIdArray",
                principalTable: "Category",
                principalColumn: "CategoryIdArray",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryStore_Category_CategoryIdArray",
                table: "CategoryStore",
                column: "CategoryIdArray",
                principalTable: "Category",
                principalColumn: "CategoryIdArray",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryIdArray",
                table: "Product",
                column: "CategoryIdArray",
                principalTable: "Category",
                principalColumn: "CategoryIdArray",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
