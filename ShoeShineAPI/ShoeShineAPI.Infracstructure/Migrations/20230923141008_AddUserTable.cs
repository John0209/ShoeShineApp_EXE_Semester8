using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentStore_Store_StoreId",
                table: "CommentStore");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentStore_User_UserId",
                table: "CommentStore");

            migrationBuilder.DropTable(
                name: "CategoryStore");

            migrationBuilder.DropTable(
                name: "ImageStore");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ServiceStore");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.CreateTable(
                name: "ProductEntity",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsProductStatus = table.Column<bool>(type: "bit", nullable: false),
                    ProductAmount = table.Column<float>(type: "real", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntity", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductEntity_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreEntity",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsStoreStatus = table.Column<bool>(type: "bit", nullable: false),
                    StoreAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StoreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreEntity", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsUserStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserAccount = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(30)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserPhone = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserEntity_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryStoreEntity",
                columns: table => new
                {
                    CategoryStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryStoreEntity", x => x.CategoryStoreId);
                    table.ForeignKey(
                        name: "FK_CategoryStoreEntity_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryStoreEntity_StoreEntity_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageStoreEntity",
                columns: table => new
                {
                    ImageStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageStoreEntity", x => x.ImageStoreId);
                    table.ForeignKey(
                        name: "FK_ImageStoreEntity_StoreEntity_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingStoresEntity",
                columns: table => new
                {
                    RatingStoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    RatingStoreScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingStoresEntity", x => x.RatingStoresId);
                    table.ForeignKey(
                        name: "FK_Rating_Store",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStoreEntity",
                columns: table => new
                {
                    ServiceStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStoreEntity", x => x.ServiceStoreId);
                    table.ForeignKey(
                        name: "FK_ServiceStoreEntity_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceStoreEntity_StoreEntity_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStoreEntity_CategoryId",
                table: "CategoryStoreEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStoreEntity_StoreId",
                table: "CategoryStoreEntity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStoreEntity_StoreId",
                table: "ImageStoreEntity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_CategoryId",
                table: "ProductEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingStoresEntity_StoreId",
                table: "RatingStoresEntity",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceStoreEntity_ServiceId",
                table: "ServiceStoreEntity",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceStoreEntity_StoreId",
                table: "ServiceStoreEntity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntity_RoleId",
                table: "UserEntity",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentStore_StoreEntity_StoreId",
                table: "CommentStore",
                column: "StoreId",
                principalTable: "StoreEntity",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentStore_UserEntity_UserId",
                table: "CommentStore",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
