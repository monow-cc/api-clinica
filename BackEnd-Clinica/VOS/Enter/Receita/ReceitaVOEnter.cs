using BackEnd_Clinica.VOS.Enter.ReceitaArquivo;

namespace BackEnd_Clinica.VOS.Enter.Receita
{
    public class ReceitaVOEnter
    {
        public string Description { get; set; }
        public Guid PacienteClinicaId { get; set; }
        public ICollection<ReceitaArquivoVOEnter>? Arquivos { get; set; }
    }
}
