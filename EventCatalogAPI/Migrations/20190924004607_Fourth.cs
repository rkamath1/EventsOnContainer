using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventCategories_EventCategoryId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventLocations_EventLocationId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventTypes_EventTypeId",
                table: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "EventCatalog");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventTypeId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventLocationId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventCategoryId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCatalog",
                table: "EventCatalog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_EventCategories_EventCategoryId",
                table: "EventCatalog",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_EventLocations_EventLocationId",
                table: "EventCatalog",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_EventTypes_EventTypeId",
                table: "EventCatalog",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventCategories_EventCategoryId",
                table: "EventCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventLocations_EventLocationId",
                table: "EventCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventTypes_EventTypeId",
                table: "EventCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCatalog",
                table: "EventCatalog");

            migrationBuilder.RenameTable(
                name: "EventCatalog",
                newName: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventTypeId",
                table: "Catalog",
                newName: "IX_Catalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventLocationId",
                table: "Catalog",
                newName: "IX_Catalog_EventLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventCategoryId",
                table: "Catalog",
                newName: "IX_Catalog_EventCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventCategories_EventCategoryId",
                table: "Catalog",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventLocations_EventLocationId",
                table: "Catalog",
                column: "EventLocationId",
                principalTable: "EventLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventTypes_EventTypeId",
                table: "Catalog",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
