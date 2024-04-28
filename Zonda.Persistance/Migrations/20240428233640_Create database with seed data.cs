using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zonda.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Createdatabasewithseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Contact", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("c61c5694-cbf1-483f-8d1d-8016184483e6"), "17 lascelles boulevard, toronto, on, canada", "437-578-XXXX", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Shanta Akther Saniya" },
                    { new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"), "17 lascelles boulevard, toronto, on, canada", "437-460-XXXX", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Arifuzzaman Tanin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0822d701-156f-4542-801b-9e1eab52d06b"), 6, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Sportneer Bike Lock", 33m },
                    { new Guid("1b40ad6a-36f3-4b1f-b896-505c1bb6003c"), 4, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "H390 Wired Headset for PC/Laptop", 29m },
                    { new Guid("31da689c-6ff7-4057-afdc-9ab022629cd3"), 2, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Monitor Stand", 50m },
                    { new Guid("597056d7-5726-4f6f-a0a9-7ed8e8869d1d"), 3, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Keyboard with Palm Rest", 49m },
                    { new Guid("edce20cc-4090-49da-b75c-53b1eb69a83a"), 5, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Canon PIXMA TS3420 Printer", 69m },
                    { new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"), 1, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Full HD 1080p Webcam", 300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_CustomerId",
                table: "CustomerOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_ProductId",
                table: "CustomerOrders",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
