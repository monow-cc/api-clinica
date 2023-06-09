using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class addresultado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Created_At = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PacienteClinicaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_PacientesClinica_PacienteClinicaId",
                        column: x => x.PacienteClinicaId,
                        principalTable: "PacientesClinica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoArquivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    ResultadoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoArquivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultadoArquivos_Resultados_ResultadoId",
                        column: x => x.ResultadoId,
                        principalTable: "Resultados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoArquivos_ResultadoId",
                table: "ResultadoArquivos",
                column: "ResultadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_PacienteClinicaId",
                table: "Resultados",
                column: "PacienteClinicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultadoArquivos");

            migrationBuilder.DropTable(
                name: "Resultados");
        }
    }
}
