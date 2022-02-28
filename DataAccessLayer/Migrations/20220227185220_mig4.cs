using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Products_ProductId",
                table: "Banners");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropColumn(
                name: "ProductSeries",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Banners",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Banners_ProductId",
                table: "Banners",
                newName: "IX_Banners_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryParentId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AboutTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesImage = table.Column<int>(type: "int", nullable: false),
                    SeriesName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SeriesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SeriesId",
                table: "Products",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Categories_CategoryId",
                table: "Banners",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Series_SeriesId",
                table: "Products",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Categories_CategoryId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Series_SeriesId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Products_SeriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AboutTitle",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Banners",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Banners_CategoryId",
                table: "Banners",
                newName: "IX_Banners_ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "ProductSeries",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Products_ProductId",
                table: "Banners",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
