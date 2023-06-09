namespace BackEnd_Clinica.VOS.Enter.Agendamento
{
    public class AgendamentoVOEnter
    {
        public Guid PacienteId { get; set; }
        public Guid ProfissionalId { get; set; }
        public Guid PacienteClinicaId { get; set; }

        public Guid TratamentoId {get;set;}
        public DateTime Data { get; set; }
        public int Tipo { get; set; }
        public string Horario { get; set; } 
        public bool Pago { get; set; }
        public int Metodo { get; set; }
        public string ConnectionId { get; set; }
    }
}
