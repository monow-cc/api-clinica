using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proprietarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    ProprietarioId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinicas_Proprietarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacientesClinica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesClinica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacientesClinica_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientesClinica_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfissionalClinicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissionalClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionalClinicas_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfissionalClinicas_Profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TratamentoClinicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    MostrarApp = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentoClinicas_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TratamentoClinicaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Horario = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pago = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_TratamentoClinicas_TratamentoClinicaId",
                        column: x => x.TratamentoClinicaId,
                        principalTable: "TratamentoClinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ClinicaId",
                table: "Agendamento",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_PacienteId",
                table: "Agendamento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ProfissionalId",
                table: "Agendamento",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_TratamentoClinicaId",
                table: "Agendamento",
                column: "TratamentoClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_ProprietarioId",
                table: "Clinicas",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesClinica_ClinicaId",
                table: "PacientesClinica",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesClinica_PacienteId",
                table: "PacientesClinica",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionalClinicas_ClinicaId",
                table: "ProfissionalClinicas",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionalClinicas_ProfissionalId",
                table: "ProfissionalClinicas",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoClinicas_ClinicaId",
                table: "TratamentoClinicas",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClinicaId",
                table: "Users",
                column: "ClinicaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "PacientesClinica");

            migrationBuilder.DropTable(
                name: "ProfissionalClinicas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TratamentoClinicas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Profissional");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Proprietarios");
        }
    }
}
