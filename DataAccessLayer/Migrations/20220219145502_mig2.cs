using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Banners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubCategoryId",
                table: "Categories",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ProductId",
                table: "Brands",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_ProductId",
                table: "Banners",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Products_ProductId",
                table: "Banners",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Products_ProductId",
                table: "Brands",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SubCategories_SubCategoryId",
                table: "Categories",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "SubCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Products_ProductId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Products_ProductId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SubCategories_SubCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_ProductId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Banners_ProductId",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Banners");
        }
    }
}
