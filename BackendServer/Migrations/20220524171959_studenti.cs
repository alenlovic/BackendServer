using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendServer.Migrations
{
    public partial class studenti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GodinaStudija = table.Column<int>(type: "int", nullable: false),
                    BrojIndeksa = table.Column<int>(type: "int", nullable: false),
                    GodinaRodjenja = table.Column<int>(type: "int", nullable: false),
                    Smjer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
