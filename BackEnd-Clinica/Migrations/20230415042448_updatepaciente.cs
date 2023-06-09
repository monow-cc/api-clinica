using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class updatepaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Altura",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Peso",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Pacientes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Pacientes");
        }
    }
}
