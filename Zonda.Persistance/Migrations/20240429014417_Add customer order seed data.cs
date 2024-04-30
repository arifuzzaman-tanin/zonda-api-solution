using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zonda.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Addcustomerorderseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerOrders",
                columns: new[] { "Id", "CreatedOn", "CustomerId", "DeletedOn", "IsDeleted", "ModifiedOn", "ProductId" },
                values: new object[,]
                {
                    { new Guid("b3ab9ca6-03d2-4d2c-b15b-fcddb7d9c4c2"), new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"), null, false, null, new Guid("597056d7-5726-4f6f-a0a9-7ed8e8869d1d") },
                    { new Guid("cc931cd1-069d-4026-b3a7-725b77b8c4d0"), new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"), null, false, null, new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc") },
                    { new Guid("ced338c2-f13e-4a40-9c9c-67e697f04b88"), new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"), null, false, null, new Guid("31da689c-6ff7-4057-afdc-9ab022629cd3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: new Guid("b3ab9ca6-03d2-4d2c-b15b-fcddb7d9c4c2"));

            migrationBuilder.DeleteData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: new Guid("cc931cd1-069d-4026-b3a7-725b77b8c4d0"));

            migrationBuilder.DeleteData(
                table: "CustomerOrders",
                keyColumn: "Id",
                keyValue: new Guid("ced338c2-f13e-4a40-9c9c-67e697f04b88"));
        }
    }
}
