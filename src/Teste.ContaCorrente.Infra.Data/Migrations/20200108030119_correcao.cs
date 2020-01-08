using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.ContaCorrente.Infra.Data.Migrations
{
    public partial class correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "int",
                table: "CONTA",
                newName: "COD_CONTA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COD_CONTA",
                table: "CONTA",
                newName: "int");
        }
    }
}
