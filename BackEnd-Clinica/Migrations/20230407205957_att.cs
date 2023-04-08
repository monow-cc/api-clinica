using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Profissional_ProfissionalId",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "ProfissionalId",
                table: "Agendamento",
                newName: "ProfissionalClinicaId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_ProfissionalId",
                table: "Agendamento",
                newName: "IX_Agendamento_ProfissionalClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_ProfissionalClinicas_ProfissionalClinicaId",
                table: "Agendamento",
                column: "ProfissionalClinicaId",
                principalTable: "ProfissionalClinicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_ProfissionalClinicas_ProfissionalClinicaId",
                table: "Agendamento");

            migrationBuilder.RenameColumn(
                name: "ProfissionalClinicaId",
                table: "Agendamento",
                newName: "ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_ProfissionalClinicaId",
                table: "Agendamento",
                newName: "IX_Agendamento_ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Profissional_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
