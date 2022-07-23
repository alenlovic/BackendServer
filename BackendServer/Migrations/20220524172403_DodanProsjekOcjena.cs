using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendServer.Migrations
{
    public partial class DodanProsjekOcjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ProsjekOcjena",
                table: "Studenti",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProsjekOcjena",
                table: "Studenti");
        }
    }
}
