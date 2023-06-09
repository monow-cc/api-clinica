using BackEnd_Clinica.VOS.Exit.ReceitaArquivo;
using BackEnd_Clinica.VOS.Exit.ResultadoArquivo;

namespace BackEnd_Clinica.VOS.Exit.Reultado
{
    public class ResultadoVOExit
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public ICollection<ResultadoArquivoVOExit>? Arquivos { get; set; }
    }
}
