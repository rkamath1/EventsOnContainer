using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventCategories_EventCategoryId",
                table: "EventCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_EventTypes_EventTypeId",
                table: "EventCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCatalog",
                table: "EventCatalog");

            migrationBuilder.DropSequence(
                name: "event_catalog_hilo");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "City",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "EventDescription",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "State",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "VenueName",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "EventCatalog");

            migrationBuilder.RenameTable(
                name: "EventCatalog",
                newName: "Catalog");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Catalog",
                newName: "TicketPrice");

            migrationBuilder.RenameColumn(
                name: "OrganizerName",
                table: "Catalog",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Catalog",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventTypeId",
                table: "Catalog",
                newName: "IX_Catalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCatalog_EventCategoryId",
                table: "Catalog",
                newName: "IX_Catalog_EventCategoryId");

            migrationBuilder.CreateSequence(
                name: "event_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_location_hilo",
                incrementBy: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Catalog",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Catalog",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "EventLocationId",
                table: "Catalog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CatalogLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_EventLocationId",
                table: "Catalog",
                column: "EventLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_EventCategories_EventCategoryId",
                table: "Catalog",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogLocations_EventLocationId",
                table: "Catalog",
                column: "EventLocationId",
                principalTable: "CatalogLocations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventCategories_EventCategoryId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_CatalogLocations_EventLocationId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_EventTypes_EventTypeId",
                table: "Catalog");

            migrationBuilder.DropTable(
                name: "CatalogLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Catalog_EventLocationId",
                table: "Catalog");

            migrationBuilder.DropSequence(
                name: "event_hilo");

            migrationBuilder.DropSequence(
                name: "event_location_hilo");

            migrationBuilder.DropColumn(
                name: "EventLocationId",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "EventCatalog");

            migrationBuilder.RenameColumn(
                name: "TicketPrice",
                table: "EventCatalog",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EventCatalog",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "EventCatalog",
                newName: "OrganizerName");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventTypeId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_EventCategoryId",
                table: "EventCatalog",
                newName: "IX_EventCatalog_EventCategoryId");

            migrationBuilder.CreateSequence(
                name: "event_catalog_hilo",
                incrementBy: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "EventCatalog",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "EventCatalog",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "EventCatalog",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "EventCatalog",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "EventCatalog",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventDescription",
                table: "EventCatalog",
                maxLength: 10000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "EventCatalog",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VenueName",
                table: "EventCatalog",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "EventCatalog",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

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
                name: "FK_EventCatalog_EventTypes_EventTypeId",
                table: "EventCatalog",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
