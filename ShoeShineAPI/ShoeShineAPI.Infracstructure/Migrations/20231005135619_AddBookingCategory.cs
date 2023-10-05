using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Category_CategoryId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_CategoryId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CategoryIdArray",
                table: "Booking");

            migrationBuilder.CreateTable(
                name: "BookingCategory",
                columns: table => new
                {
                    BookingCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCategory", x => x.BookingCategoryId);
                    table.ForeignKey(
                        name: "FK_BookingCategory_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryIdArray",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCategory_BookingId",
                table: "BookingCategory",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCategory_CategoryId",
                table: "BookingCategory",
                column: "CategoryIdArray");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdArray",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CategoryId",
                table: "Booking",
                column: "CategoryIdArray");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Category_CategoryId",
                table: "Booking",
                column: "CategoryIdArray",
                principalTable: "Category",
                principalColumn: "CategoryIdArray",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
