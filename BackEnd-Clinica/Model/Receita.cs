namespace BackEnd_Clinica.Model
{
    public class Receita
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public Guid PacienteClinicaId { get; set; }
        public PacienteClinica? PacienteClinica { get; set; }
        public ICollection<ReceitaArquivos>? ReceitaArquivos { get; set; }
    }
}
