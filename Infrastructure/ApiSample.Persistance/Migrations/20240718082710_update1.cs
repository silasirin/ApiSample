using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiSample.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(1863), "Games & Baby" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(1887), "Shoes, Movies & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(1894), "Games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 7, 18, 11, 27, 10, 566, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 568, DateTimeKind.Local).AddTicks(5366), "Quia aliquam camisi deleniti architecto.", "İncidunt." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 568, DateTimeKind.Local).AddTicks(5453), "Sokaklarda koyun ötekinden öyle ut.", "Bahar sokaklarda." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 568, DateTimeKind.Local).AddTicks(5488), "Gördüm ut explicabo sarmal voluptatem.", "Neque." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 572, DateTimeKind.Local).AddTicks(3337), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 4.231611447702530m, 810.37m, "Unbranded Fresh Car" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 7, 18, 11, 27, 10, 572, DateTimeKind.Local).AddTicks(3368), "The Football Is Good For Training And Recreational Purposes", 3.065831288359440m, 576.41m, "Incredible Wooden Ball" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(4519), "Electronics" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(4590), "Toys, Tools & Music" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(4610), "Health & Industrial" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 11, 23, 22, 3, 607, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 610, DateTimeKind.Local).AddTicks(5244), "Consequuntur mutlu eum umut quaerat.", "Un." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 610, DateTimeKind.Local).AddTicks(5297), "Sed quia orta çobanın de.", "Sit duyulmamış." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 610, DateTimeKind.Local).AddTicks(5333), "Consequatur bundan doloremque gitti sinema.", "Architecto." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 624, DateTimeKind.Local).AddTicks(7838), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 0.2734516991568180m, 62.53m, "Handcrafted Rubber Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 6, 11, 23, 22, 3, 624, DateTimeKind.Local).AddTicks(7874), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 5.287431664706050m, 966.10m, "Gorgeous Concrete Fish" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
