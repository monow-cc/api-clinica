namespace BackEnd_Clinica.Model
{
    public class GeradorPaciente
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public Guid PacienteId { get; set; }

        public Clinica? Clinica { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
