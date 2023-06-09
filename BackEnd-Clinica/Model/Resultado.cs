namespace BackEnd_Clinica.Model
{
    public class Resultado
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public Guid PacienteClinicaId { get; set; }
        public PacienteClinica? PacienteClinica { get; set; }
        public ICollection<ResultadoArquivo>? ResultadoArquivos { get; set; }
    }
}
