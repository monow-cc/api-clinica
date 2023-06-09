using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_Clinica.Migrations
{
    /// <inheritdoc />
    public partial class cadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cadastro",
                table: "Pacientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cadastro",
                table: "Pacientes");
        }
    }
}
