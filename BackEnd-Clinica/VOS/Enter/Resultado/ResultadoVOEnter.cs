using BackEnd_Clinica.VOS.Enter.ReceitaArquivo;
using BackEnd_Clinica.VOS.Enter.ResultadoArquivo;

namespace BackEnd_Clinica.VOS.Enter.Resultado
{
    public class ResultadoVOEnter
    {
        public string Description { get; set; }
        public Guid PacienteClinicaId { get; set; }
        public ICollection<ResultadoArquivoVOEnter>? Arquivos { get; set; }
    }
}
