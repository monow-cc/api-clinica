namespace BackEnd_Clinica.Model
{
    public class ProfissionalClinica
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public Clinica? Clinica { get; set; }
        public Guid ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }
        public int Status { get; set; }
    }
}
