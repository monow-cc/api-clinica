using BackEnd_Clinica.VOS.Exit.PacienteClinica;
using BackEnd_Clinica.VOS.Exit.ProfissionalClinica;
using BackEnd_Clinica.VOS.Exit.TratamentoClinica;

namespace BackEnd_Clinica.VOS.Exit.Clinica
{
    public class ClinicaAuthVOExit
    {
        public string Nome { get; set; }
        public ICollection<PacienteClinicaVOExit> Pacientes { get; set; }
        public ICollection<TratamentoClinicaVOExit> Tratamentos { get; set; }
        public ICollection<ProfissionalClinicaVOExit> Profissionais { get; set; }

    }
}
