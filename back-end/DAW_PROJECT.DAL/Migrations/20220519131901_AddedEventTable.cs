using Microsoft.EntityFrameworkCore.Migrations;

namespace DAW_PROJECT.DAL.Migrations
{
    public partial class AddedEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZiDesfasurare = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocatieEventId = table.Column<int>(type: "int", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    NumarBilete = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
