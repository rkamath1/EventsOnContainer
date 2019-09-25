using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_CatalogLocations_EventLocationId",
                table: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogLocations",
                table: "CatalogLocations");

            migrationBuilder.RenameTable(
                name: "CatalogLocations",
                newName: "EventLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventLocations",
                table: "EventLocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventLocations_EventLocationId",
                table: "Catalog",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventLocations_EventLocationId",
                table: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventLocations",
                table: "EventLocations");

            migrationBuilder.RenameTable(
                name: "EventLocations",
                newName: "CatalogLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogLocations",
                table: "CatalogLocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogLocations_EventLocationId",
                table: "Catalog",
                column: "EventLocationId",
                principalTable: "CatalogLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
