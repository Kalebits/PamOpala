using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OpalaAPIPam.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<long>(type: "bigint", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoEnum = table.Column<int>(type: "int", nullable: false),
                    generoEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeBanda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estilo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banda_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Cont = table.Column<DateTime>(type: "datetime2", nullable: true),
                    duracao = table.Column<int>(type: "int", nullable: false),
                    Dt_Apresentacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instrumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrumento_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Endereco", "Nome", "Senha", "Telefone", "generoEnum", "tipoEnum" },
                values: new object[,]
                {
                    { 1, "PedroS@gmail.com", "", "Pedro Silva", "pedrinho123", null, 0, 0 },
                    { 2, "gHenrique@gmail.com", "", "Gustavo Henrique", "henrique123", null, 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_usuarioId",
                table: "Avaliacao",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Banda_usuarioId",
                table: "Banda",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_usuarioId",
                table: "Contrato",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumento_usuarioId",
                table: "Instrumento",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Banda");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Instrumento");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
