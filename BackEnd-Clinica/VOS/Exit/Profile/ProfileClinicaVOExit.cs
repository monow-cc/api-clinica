using BackEnd_Clinica.VOS.Exit.Agendamento;
using BackEnd_Clinica.VOS.Exit.Receita;
using BackEnd_Clinica.VOS.Exit.Reultado;

namespace BackEnd_Clinica.VOS.Exit.Profile
{
    public class ProfileClinicaVOExit
    {
        public Guid PacientId { get; set; }
        public string Name { get; set; }
        public ICollection<ReceitaVOExit>? Receitas { get; set; }
        public ICollection<ResultadoVOExit>? Resultados { get; set; }
        public ICollection<AgendamentoVOExit>? Historicos { get; set; }
    }
}
