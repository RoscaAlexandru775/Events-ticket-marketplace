using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_PROJECT.DAL.Migrations
{
    public partial class AdedOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events",
                column: "OrganizatorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizatorId",
                table: "Events",
                column: "OrganizatorId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizatorId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events");
        }
    }
}
