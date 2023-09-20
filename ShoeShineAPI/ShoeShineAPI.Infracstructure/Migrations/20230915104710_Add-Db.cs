using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsCategoryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "RatingComment",
                columns: table => new
                {
                    RatingCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingCommentScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingComment", x => x.RatingCommentId);
                });

            migrationBuilder.CreateTable(
                name: "RatingStoresEntity",
                columns: table => new
                {
                    RatingStoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingStoreScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingStores", x => x.RatingStoresId);
                });

            migrationBuilder.CreateTable(
                name: "RoleEntity",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ServicePrice = table.Column<float>(type: "real", nullable: false),
                    IsServiceStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntity",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    ProductAmount = table.Column<float>(type: "real", nullable: false),
                    IsProductStatus = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreEntity",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StoreAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    StoreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsStoreStatus = table.Column<bool>(type: "bit", nullable: false),
                    RatingStoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Rating_Store",
                        column: x => x.RatingStoresId,
                        principalTable: "RatingStoresEntity",
                        principalColumn: "RatingStoresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserPhone = table.Column<string>(type: "varchar(15)", nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(30)", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserAccount = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserPassword = table.Column<string>(type: "varchar(20)", nullable: false),
                    IsUserStatus = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleEntity",
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
                    table.PrimaryKey("PK_CategoryStore", x => x.CategoryStoreId);
                    table.ForeignKey(
                        name: "FK_CategoryStore_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductEntity",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Image_Store_StoreId",
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
                    table.PrimaryKey("PK_ServiceStore", x => x.ServiceStoreId);
                    table.ForeignKey(
                        name: "FK_ServiceStore_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreEntity",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    RatingCommentId = table.Column<int>(type: "int", nullable: false)
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
                        principalTable: "RatingComment",
                        principalColumn: "RatingCommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageComment",
                columns: table => new
                {
                    ImageCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageCommentURL = table.Column<string>(type: "varchar(100)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageComment", x => x.ImageCommentId);
                    table.ForeignKey(
                        name: "FK_ImageComment_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStore_CategoryId",
                table: "CategoryStoreEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStore_StoreId",
                table: "CategoryStoreEntity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RatingCommentId",
                table: "Comment",
                column: "RatingCommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StoreId",
                table: "Comment",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_StoreId",
                table: "Image",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageComment_CommentId",
                table: "ImageComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "ProductEntity",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceStore_ServiceId",
                table: "ServiceStoreEntity",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceStore_StoreId",
                table: "ServiceStoreEntity",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_RatingStoresId",
                table: "StoreEntity",
                column: "RatingStoresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "UserEntity",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryStoreEntity");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ImageComment");

            migrationBuilder.DropTable(
                name: "ServiceStoreEntity");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ProductEntity");

            migrationBuilder.DropTable(
                name: "StoreEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropTable(
                name: "RatingComment");

            migrationBuilder.DropTable(
                name: "CategoryEntity");

            migrationBuilder.DropTable(
                name: "RatingStoresEntity");

            migrationBuilder.DropTable(
                name: "RoleEntity");
        }
    }
}
