using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace clothesbackend.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<double>(type: "float", nullable: false),
                    number = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    rate = table.Column<double>(type: "float", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catrgoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_catrgoryID",
                        column: x => x.catrgoryID,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false),
                    attriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => new { x.productID, x.attriID });
                    table.ForeignKey(
                        name: "FK_Stock_attries_attriID",
                        column: x => x.attriID,
                        principalTable: "attries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_products_productID",
                        column: x => x.productID,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "attries",
                columns: new[] { "id", "color", "number", "size" },
                values: new object[,]
                {
                    { 1, "red", 2.0, 38.0 },
                    { 2, "green", 3.0, 40.0 },
                    { 3, "red", 1.0, 39.0 },
                    { 4, "red", 2.0, 41.0 },
                    { 5, "yellow", 2.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Men's Clothing" },
                    { 2, "Women's Clothing" },
                    { 3, "Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "catrgoryID", "count", "image", "name", "price", "rate", "title" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "Mens Casual Premium Slim Fit T - Shirts", 33.399999999999999, 0.0, "Men" },
                    { 2, 1, 0, null, "Mens Cotton Jacket ", 12.4, 0.0, "Men" },
                    { 3, 2, 0, null, "Ao nu 1", 33.399999999999999, 0.0, "Women" },
                    { 4, 3, 0, null, "Vong Vang nay no a", 33.399999999999999, 0.0, "Jewelery" }
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "attriID", "productID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_catrgoryID",
                table: "products",
                column: "catrgoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_attriID",
                table: "Stock",
                column: "attriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "attries");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
