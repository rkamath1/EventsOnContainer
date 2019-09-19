using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_type_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 100, nullable: false),
                    OrganizerName = table.Column<string>(maxLength: 100, nullable: true),
                    EventDescription = table.Column<string>(maxLength: 10000, nullable: false),
                    VenueName = table.Column<string>(maxLength: 250, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 300, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 300, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 30, nullable: false),
                    Zip = table.Column<string>(maxLength: 5, nullable: false),
                    Date = table.Column<string>(maxLength: 10, nullable: false),
                    Time = table.Column<string>(maxLength: 7, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCatalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCatalog_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCatalog_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_EventCategoryId",
                table: "EventCatalog",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_EventTypeId",
                table: "EventCatalog",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCatalog");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropSequence(
                name: "event_catalog_hilo");

            migrationBuilder.DropSequence(
                name: "event_category_hilo");

            migrationBuilder.DropSequence(
                name: "event_type_hilo");
        }
    }
}
