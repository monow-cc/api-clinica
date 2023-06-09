namespace BackEnd_Clinica.Model
{
    public class PacienteClinica
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public Guid PacienteId { get; set; }
        public Clinica? Clinica { get; set; }
        public Paciente? Paciente { get; set; }
        public ICollection<Receita>? Receitas { get; set; }
        public ICollection<Resultado>? Resultados { get; set; }
        public ICollection<Agendamento>? Historicos { get; set; }
    }
}