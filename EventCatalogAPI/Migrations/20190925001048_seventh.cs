using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "EventLocations",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EventCatalog",
                newName: "VenueName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "EventCatalog",
                newName: "EventDescription");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "EventLocations",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "EventCatalog",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizerName",
                table: "EventCatalog",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "EventLocations");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "OrganizerName",
                table: "EventCatalog");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "EventLocations",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "VenueName",
                table: "EventCatalog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "EventCatalog",
                newName: "Description");
        }
    }
}
