namespace BackEnd_Clinica.VOS.Exit.PacienteClinica
{
    public class PacienteClinicaVOExit
    {
        public Guid Id { get; set; }
        public Guid PacienteClinicaId { get; set; }
        public long Cadastro { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
    }
}
