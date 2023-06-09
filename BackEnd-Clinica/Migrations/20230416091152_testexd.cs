using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class testexd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PacienteClinicaId",
                table: "Agendamento",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteClinicaId",
                table: "Agendamento",
                column: "PacienteClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_PacientesClinica_PacienteClinicaId",
                table: "Agendamento",
                column: "PacienteClinicaId",
                principalTable: "PacientesClinica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_PacientesClinica_PacienteClinicaId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_PacienteClinicaId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "PacienteClinicaId",
                table: "Agendamento");
        }
    }
}
