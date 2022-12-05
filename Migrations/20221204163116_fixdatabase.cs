using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clothesbackend.Migrations
{
    /// <inheritdoc />
    public partial class fixdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_catrgoryID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "catrgoryID",
                table: "products",
                newName: "categoryID");

            migrationBuilder.RenameIndex(
                name: "IX_products_catrgoryID",
                table: "products",
                newName: "IX_products_categoryID");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "attries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_categoryID",
                table: "products",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_categoryID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "products",
                newName: "catrgoryID");

            migrationBuilder.RenameIndex(
                name: "IX_products_categoryID",
                table: "products",
                newName: "IX_products_catrgoryID");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "attries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_catrgoryID",
                table: "products",
                column: "catrgoryID",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
