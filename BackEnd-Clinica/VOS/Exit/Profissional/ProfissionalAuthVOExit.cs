using BackEnd_Clinica.VOS.Exit.Clinica;

namespace BackEnd_Clinica.VOS.Exit.Profissional
{
    public class ProfissionalAuthVOExit
    {
        public string Nome { get; set; }
        public ICollection<ClinicaProfVOExit>? Clinicas { get; set; }
    }
}
