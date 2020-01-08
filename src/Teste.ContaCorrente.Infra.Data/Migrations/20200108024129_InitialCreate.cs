using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.ContaCorrente.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANCO",
                columns: table => new
                {
                    ID_BANCO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_BANCO = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANCO", x => x.ID_BANCO);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID_CLIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(200)", nullable: true),
                    CPF = table.Column<decimal>(type: "numeric(11,0)", nullable: false),
                    DT_NASC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "CONTA",
                columns: table => new
                {
                    ID_CONTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    @int = table.Column<int>(name: "int", nullable: false),
                    AGENCIA = table.Column<int>(type: "int", nullable: false),
                    SALDO = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    LIMITE = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ID_CLIENTE = table.Column<int>(type: "int", nullable: false),
                    ID_BANCO = table.Column<int>(type: "int", nullable: false),
                    DT_ABERTURA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ATIVA = table.Column<bool>(type: "bit", nullable: false),
                    DT_FECHAMENTO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA", x => x.ID_CONTA);
                    table.ForeignKey(
                        name: "FK_CONTA_BANCO_ID_BANCO",
                        column: x => x.ID_BANCO,
                        principalTable: "BANCO",
                        principalColumn: "ID_BANCO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTA_CLIENTE_ID_CLIENTE",
                        column: x => x.ID_CLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "ID_CLIENTE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LANCAMENTO",
                columns: table => new
                {
                    ID_LANCAMENTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VALOR = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DT_LANCAMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_CONTA_ORIGEM = table.Column<int>(type: "int", nullable: false),
                    ID_CONTA_DESTINO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANCAMENTO", x => x.ID_LANCAMENTO);
                    table.ForeignKey(
                        name: "FK_LANCAMENTO_CONTA_ID_CONTA_DESTINO",
                        column: x => x.ID_CONTA_DESTINO,
                        principalTable: "CONTA",
                        principalColumn: "ID_CONTA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LANCAMENTO_CONTA_ID_CONTA_ORIGEM",
                        column: x => x.ID_CONTA_ORIGEM,
                        principalTable: "CONTA",
                        principalColumn: "ID_CONTA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_ID_BANCO",
                table: "CONTA",
                column: "ID_BANCO");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_ID_CLIENTE",
                table: "CONTA",
                column: "ID_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_LANCAMENTO_ID_CONTA_DESTINO",
                table: "LANCAMENTO",
                column: "ID_CONTA_DESTINO");

            migrationBuilder.CreateIndex(
                name: "IX_LANCAMENTO_ID_CONTA_ORIGEM",
                table: "LANCAMENTO",
                column: "ID_CONTA_ORIGEM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LANCAMENTO");

            migrationBuilder.DropTable(
                name: "CONTA");

            migrationBuilder.DropTable(
                name: "BANCO");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
