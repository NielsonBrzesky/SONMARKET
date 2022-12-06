using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONMARKET.Migrations
{
    public partial class AcertoPorcentagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Procentagem",
                table: "Promocoes",
                newName: "Porcentagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Porcentagem",
                table: "Promocoes",
                newName: "Procentagem");
        }
    }
}
