using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_PROJECT.DAL.Migrations
{
    public partial class AdedOneToOnev4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizatorId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizatorId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events",
                column: "OrganizatorId",
                unique: true,
                filter: "[OrganizatorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizatorId",
                table: "Events",
                column: "OrganizatorId",
                principalTable: "Organizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizatorId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_OrganizatorId",
                table: "Events");

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
    }
}
