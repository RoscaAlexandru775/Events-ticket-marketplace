using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_PROJECT.DAL.Migrations
{
    public partial class AddOnToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LocatieEventId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizatorId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EventId",
                table: "Locations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events",
                column: "OrganizatorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Events_EventId",
                table: "Locations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Events_EventId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_EventId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizatorId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LocatieEventId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events",
                column: "OrganizatorId",
                unique: true,
                filter: "[OrganizatorId] IS NOT NULL");
        }
    }
}
