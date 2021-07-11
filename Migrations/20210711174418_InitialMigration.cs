using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Netfritz.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fitas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Cartao = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ClienteEntityId = table.Column<string>(type: "text", nullable: false),
                    FitaEntityId = table.Column<string>(type: "text", nullable: false),
                    Avaliacao_Nota = table.Column<int>(type: "integer", nullable: true),
                    Avaliacao_Comentario = table.Column<string>(type: "text", nullable: true),
                    DataCompra = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Fitas_FitaEntityId",
                        column: x => x.FitaEntityId,
                        principalTable: "Fitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_ClienteEntityId",
                        column: x => x.ClienteEntityId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteEntityId",
                table: "Compras",
                column: "ClienteEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FitaEntityId",
                table: "Compras",
                column: "FitaEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Fitas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
