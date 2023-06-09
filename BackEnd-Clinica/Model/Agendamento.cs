using System.ComponentModel.DataAnnotations;

namespace BackEnd_Clinica.Model
{
    public class Agendamento
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ClinicaId {get;set;}
        public Guid ProfissionalClinicaId { get; set;}
        public Guid PacienteClinicaId { get; set;}
        public Guid PacienteId { get; set;}
        public Guid TratamentoClinicaId { get; set;}
        public int Tipo { get; set;}
        public string Horario { get; set;}
        public DateTime Data { get; set;}
        public bool Pago { get; set;}
        public int Metodo { get; set;}
        
        public Clinica? Clinica { get; set;}
        public ProfissionalClinica? ProfissionalClinica { get; set;}
        public Paciente? Paciente { get; set;}
        public TratamentoClinica? TratamentoClinica { get; set; }
        public PacienteClinica? PacienteClinica { get; set;}
    }
}
