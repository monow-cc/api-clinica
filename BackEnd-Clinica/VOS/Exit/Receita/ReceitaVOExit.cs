using BackEnd_Clinica.VOS.Enter.ReceitaArquivo;
using BackEnd_Clinica.VOS.Exit.ReceitaArquivo;

namespace BackEnd_Clinica.VOS.Exit.Receita
{
    public class ReceitaVOExit
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public ICollection<ReceitaArquivoVOExit>? Arquivos { get; set; }
    }
}
