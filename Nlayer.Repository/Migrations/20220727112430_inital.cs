using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nlayer.Repository.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Widht = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    productFeatureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Producs_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Producs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_ProductFeatures_productFeatureId",
                        column: x => x.productFeatureId,
                        principalTable: "ProductFeatures",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kalemler" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "name" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kitaplar" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "name" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Defterler" });

            migrationBuilder.InsertData(
                table: "Producs",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 7, 27, 14, 24, 30, 140, DateTimeKind.Local).AddTicks(4429), "Kalem 1", 100m, 20, null },
                    { 2, 1, new DateTime(2022, 7, 27, 14, 24, 30, 140, DateTimeKind.Local).AddTicks(4443), "Kalem 2", 200m, 30, null },
                    { 3, 1, new DateTime(2022, 7, 27, 14, 24, 30, 140, DateTimeKind.Local).AddTicks(4444), "Kalem 3", 600m, 30, null },
                    { 4, 2, new DateTime(2022, 7, 27, 14, 24, 30, 140, DateTimeKind.Local).AddTicks(4445), "Kitap 1", 600m, 60, null },
                    { 5, 2, new DateTime(2022, 7, 27, 14, 24, 30, 140, DateTimeKind.Local).AddTicks(4445), "kitap 2", 6600m, 320, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Widht", "productFeatureId" },
                values: new object[] { 1, "Kırmızı", 100, 1, 200, null });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Widht", "productFeatureId" },
                values: new object[] { 2, "Mavi", 300, 2, 500, null });

            migrationBuilder.CreateIndex(
                name: "IX_Producs_CategoryId",
                table: "Producs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_productFeatureId",
                table: "ProductFeatures",
                column: "productFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Producs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
