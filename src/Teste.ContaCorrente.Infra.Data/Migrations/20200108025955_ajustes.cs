using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.ContaCorrente.Infra.Data.Migrations
{
    public partial class ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TP_CONTA",
                table: "CONTA",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TP_CONTA",
                table: "CONTA");
        }
    }
}
