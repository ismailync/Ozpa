using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Series_SeriesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SeriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AboutVideo",
                table: "Abouts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Series_CategoryId",
                table: "Series",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Series_CategoryId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Series");

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AboutVideo",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SeriesId",
                table: "Products",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Series_SeriesId",
                table: "Products",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
