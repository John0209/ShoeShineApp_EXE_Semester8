using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeShineAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

        migrationBuilder.AddColumn<string>(
                name: "UserGender",
                table: "User",
                type: "varchar",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(
     name: "UserBirthDay",
     table: "User",
     type: "datetime2",
     nullable: false,
     defaultValue: DateTime.Parse("2000-01-01"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
