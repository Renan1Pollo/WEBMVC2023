using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBMVC.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    equipamentos = table.Column<int>(type: "int", nullable: false),
                    situacao = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    aniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cursoid = table.Column<int>(type: "int", nullable: true),
                    periodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_cursoid",
                        column: x => x.cursoid,
                        principalTable: "Cursos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alunoid = table.Column<int>(type: "int", nullable: true),
                    salaid = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Alunos_alunoid",
                        column: x => x.alunoid,
                        principalTable: "Alunos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Atendimentos_Salas_salaid",
                        column: x => x.salaid,
                        principalTable: "Salas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_cursoid",
                table: "Alunos",
                column: "cursoid");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_alunoid",
                table: "Atendimentos",
                column: "alunoid");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_salaid",
                table: "Atendimentos",
                column: "salaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
